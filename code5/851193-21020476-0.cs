      private T Read<T>(string value, T defaultValue)
            {
     TypeConverter converter = TypeDescriptor.GetConverter(typeof (T));
                        try
                        {
                            return (T) converter.ConvertFromString(value);
                        }
                        catch (FormatException)
                        {
                            return defaultValue;
                        }
                    }
                }
                return defaultValue;
            }
