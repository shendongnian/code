    public static string ObjectToString(object obj, int indent = 0)
        {
            var sb = new StringBuilder();
            if (obj != null)
            {
                string indentString = new string(' ', indent);
                if (obj is string || obj.IsNumber())
                {
                    sb.Append($"{indentString}- {obj}\n");
                }
                else if (obj.GetType().BaseType == typeof(Enum))
                {
                    sb.Append($"{indentString}- {obj.ToString()}\n");
                }
                else if (obj is Array)
                {
                    var elems = obj as IList;
                    sb.Append($"{indentString}- [{elems.Count}] :\n");
                    for (int i = 0; i < elems.Count; i++)
                    {
                        sb.Append(ObjectToString(elems[i], indent + 4));
                    }
                }
                else
                {
                    Type objType = obj.GetType();
                    PropertyInfo[] props = objType.GetProperties();
                    foreach (PropertyInfo prop in props)
                    {
                        if (prop.GetIndexParameters().Length == 0)
                        {
                            object propValue = prop.GetValue(obj);
                            var elems = propValue as IList;
                            if (elems != null)
                            {
                                foreach (var item in elems)
                                {
                                    sb.Append($"{indentString}- {prop.Name} :\n");
                                    sb.Append(ObjectToString(item, indent + 4));
                                }
                            }
                            else if (prop.Name != "ExtensionData")
                            {
                                sb.Append($"{indentString}- {prop.Name} = {propValue}\n");
                                if (prop.PropertyType.Assembly == objType.Assembly)
                                {
                                    sb.Append(ObjectToString(propValue, indent + 4));
                                }
                            }
                        }
                        else if (objType.GetProperty("Item") != null)
                        {
                            int count = -1;
                            if (objType.GetProperty("Count") != null &&
                                objType.GetProperty("Count").PropertyType == typeof(int))
                            {
                                count = (int)objType.GetProperty("Count").GetValue(obj, null);
                            }
                            for (int i = 0; i < count; i++)
                            {
                                object val = prop.GetValue(obj, new object[] { i });
                                sb.Append(ObjectToString(val, indent + 4));
                            }
                        }
                    }
                }
            }
            return sb.ToString();
        }
        public static bool IsNumber(this object value)
        {
            return value is sbyte
                || value is byte
                || value is short
                || value is ushort
                || value is int
                || value is uint
                || value is long
                || value is ulong
                || value is float
                || value is double
                || value is decimal;
        }
