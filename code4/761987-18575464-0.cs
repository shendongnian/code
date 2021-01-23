        public static DateTime DateTimeCheck(object objDateTime)
        {
            DateTime dateTime ;
            if (objDateTime != null)
            {
                if (DateTime.TryParse(objDateTime.ToString(), out dateTime))
                {
                    return Convert.ToDateTime(objDateTime);
                }
            }
            return default(DateTime);
        }
