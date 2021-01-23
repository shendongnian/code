    public static class Utils
        {
            public static int? Sum(this int? value1, int? value2)
            {
                if (!value1.HasValue && !value2.HasValue)
                    return null;
    
                int myValue1 = value1.HasValue ? value1.Value : 0;
                int myValue2 = value2.HasValue ? value1.Value : 0;
    
                return myValue1 + myValue2;
            }
        }
