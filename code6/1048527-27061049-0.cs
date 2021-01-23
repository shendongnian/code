    public static string GetEnumNameFromValue(System.Type typeEnum, string value)
            {
                FieldInfo[] fis = typeEnum.GetFields();
                foreach (FieldInfo fi in fis)
                {
                    EnumMemberAttribute[] attributes = (EnumMemberAttribute[])fi.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                    if (attributes.Length > 0)
                    {
                        if (string.Compare(attributes[0].Value, value, true) == 0)
                        {
                            return fi.Name;
                        }
                    }
                }
                return null;
            }
         
