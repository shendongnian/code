      public static TestEnum GetMyEnum(this string title)
            {    
                EnumBookType st;
                Enum.TryParse(title, out st);
                return st;          
             }
