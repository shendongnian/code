    private string ObjectToString(object obj, int indent = 0)
        {
            var sb = new StringBuilder();
            if (obj != null)
            {
                string indentString = new string(' ', indent);
                if (obj is string)
                {
                    sb.Append($"{indentString}- {obj}\n");
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
                        else
                        {
                            sb.Append($"{indentString}- {prop.Name} ({prop.PropertyType.Name}): <Indexed>\n");
                        }
                    }
                }
            }
            return sb.ToString();
        }
