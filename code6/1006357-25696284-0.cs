     public static class Program
        {
            public static void Main()
            {
                var value = "TYPE Email Forwarding".KeyValue();
                var value1 = "CLIENT NAME James Henries".KeyValue();
    
            }
    
            public static KeyValuePair<string, string> KeyValue(this string rawData)
            {
                var splitValue = rawData.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                KeyValuePair<string, string> returnValue;
    
                var key = string.Empty;
                var value = string.Empty;
                foreach (var item in splitValue)
                {
                    if (item.ToUpper() == item)
                    {
                        if (string.IsNullOrWhiteSpace(key))
                        {
                            key += item;
                        }
                        else
                        {
                            key += " " + item;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            value += item;
                        }
                        else
                        {
                            value += " "  + item;
                        }
                    }
                }
    
                returnValue = new KeyValuePair<string, string>(key, value);
                return returnValue;
            }
        }
