    public class Tools
    {
        public static string GetDescription(Enum en)
        {
            FieldInfo fi = en.GetType().GetField(en.ToString());
            DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : en.ToString(); 
        }
    }
