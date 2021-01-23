    private void PrintProperties(object obj, int indent)
        {
            if (obj == null) return;
            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                
                var elems = propValue as IList;
                if ((elems != null) && !(elems is string[]) )
                {
                    foreach (var item in elems)
                    {
                        PrintProperties(item, indent + 3);
                    }
                }
                else
                {
                    // This will not cut-off System.Collections because of the first check
                    if (property.PropertyType.Assembly == objType.Assembly)
                    {
                        LogToWindow(String.Format("{0}{1}:", indentString, property.Name));
                        PrintProperties(propValue, indent + 2);
                    }
                    else
                    {
                        if (propValue is string[])
                        {
                            var str = new StringBuilder();
                            foreach (string item in (string[])propValue)
                            {
                                str.AppendFormat("{0}; ", item);
                            }
                            propValue = str.ToString();
                            str.Clear();
                        }
                        LogToWindow(String.Format("{0}{1}: {2}", indentString, property.Name, propValue));
                    }
                }
            }
        }
