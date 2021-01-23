    private bool TrySerialize(object obj)
    {
        if (obj == null)
            return true;
        var stream = new MemoryStream();
        var bf = new BinaryFormatter();
        try
        {
            bf.Serialize(stream, obj);
        }
        catch (SerializationException)
        {
            return false;
        }
        return true;
    }
    private string FindObject(Stack<object> self, Type typeToFind, string path)
    {
        var _self = self.Peek();
        if (self.Where(x => x.Equals(_self)).Count() > 1) return null;
        foreach (var prop in _self.GetType().GetMembers().Where(x => !x.GetCustomAttributes(true).Any(y => y is XmlIgnoreAttribute)))
        {
            switch (prop.MemberType)
            {
                case System.Reflection.MemberTypes.Property:
                    {
                        var line = string.Format("{0}::{1}", path, prop.Name);
                        var _prop = prop as PropertyInfo;
                        if (_prop.GetIndexParameters().Count() > 0) break;
                        if (typeToFind.IsAssignableFrom(_prop.PropertyType))
                            return line;
                       
                        if (_prop.PropertyType.IsPrimitive || _prop.PropertyType == typeof(DateTime) || _prop.PropertyType == typeof(string))
                            continue;
                        var subInst = _prop.GetValue(_self, new object[0]);
                        if (subInst == null)
                            continue;
                        if (!TrySerialize(subInst))
                        {
                            System.Diagnostics.Debugger.Log(0,"",string.Format("Cannot serialize {0}\n", line));
                        }
                        self.Push(subInst);
                        var result = FindObject(self, typeToFind, line);
                        self.Pop();
                        if (result != null)
                            return result;
                    }
                    break;
                case System.Reflection.MemberTypes.Field:
                    {
                        var line = string.Format("{0}::*{1}", path, prop.Name);
                        var _prop = prop as FieldInfo;
                        if (typeToFind.IsAssignableFrom(_prop.FieldType))
                            return line;
                        if (_prop.FieldType.IsPrimitive || _prop.FieldType == typeof(DateTime) || _prop.FieldType == typeof(string))
                            continue;
                        var subInst = _prop.GetValue(_self);
                        if (subInst == null)
                            continue;
                        if (!TrySerialize(subInst))
                        {
                            System.Diagnostics.Debugger.Log(0, "", string.Format("Cannot serialize field {0}\n", line));
                        }
                        self.Push(subInst);
                        var result = FindObject(self, typeToFind, line);
                        self.Pop();
                        if (result != null)
                            return result;
                    }
                    break;
                case System.Reflection.MemberTypes.Event:
                    {
                        var line = string.Format("{0}::!{1}", path, prop.Name);
                        var _prop = prop as EventInfo;
                        if (typeToFind.IsAssignableFrom(_prop.EventHandlerType))
                            return line;
                        var field =  _self.GetType().GetField(_prop.Name,
                            BindingFlags.NonPublic |BindingFlags.Instance |BindingFlags.GetField);
                        
                        
                        if (field!=null && !field.GetCustomAttributes(true).Any(x=>x is NonSerializedAttribute) 
                            && !TrySerialize(field.GetValue(_self)))
                        {
                            System.Diagnostics.Debugger.Log(0, "", string.Format("Cannot serialize event {0}\n", line));
                        }
                        
                    }
                    break;
                case System.Reflection.MemberTypes.Custom:
                    {
                    }
                    break;
                default: break;
            }
        }
        if (_self is IEnumerable)
        {
            var list = (_self as IEnumerable).Cast<object>();
            var index = 0;
            foreach (var item in list)
            {
                index++;
                self.Push(item);
                var result = FindObject(self, typeToFind, string.Format("{0}[{1}]", path, index));
                self.Pop();
                if (result != null)
                    return result;
            }
        }
        return null;
    }
