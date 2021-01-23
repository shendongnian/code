       private T Read<T>(string name)
                {
                    string valueString=GetValue(name);
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof (T));
                            try
                            {
                                return (T) converter.ConvertFromString(value);
                            }
                            catch (FormatException)
                            {
                                return default(T);
                            }
                        
                }
