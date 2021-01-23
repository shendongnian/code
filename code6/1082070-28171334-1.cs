     public static void DisplayAll<TEnum>(Object obj, string[] aMessage) where TEnum : struct,  IComparable, IFormattable, IConvertible
            {
                if (!typeof(TEnum).IsEnum)
                {
                    throw new ArgumentException("T must be an enumerated type");
                }
    
                Type type = obj.GetType();
                PropertyInfo[] properties = type.GetProperties();
    
                foreach (PropertyInfo property in properties)
                {
                    TEnum t = (TEnum)Enum.Parse(typeof(TEnum), property.Name);
                    string value = aMessage[t.ToInt32(Thread.CurrentThread.CurrentCulture)].ToString();
                    System.Diagnostics.Debug.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(obj, null));
                }
            }
