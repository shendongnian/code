        public string GetFormattedDate(String MyDateTime)
        {
            //Formating should happen here.
            DateTime dt = DateTime.Parse(MyDateTime);
            return dt.ToString("yyyy/MM/dd");            
        }
