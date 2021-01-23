        private static String GetSystemTranslatedField(Enum enumtype, int? val) {
            if (!val.HasValue)
                return "";
            String tempstr;
            if (Enum.IsDefined(enumtype, val.Value))
            {
                tempstr = ((enumtype)val.Value).ToString(); 
            }
            
            ... // Rest of your code here
        }
