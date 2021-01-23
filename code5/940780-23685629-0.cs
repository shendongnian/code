        protected string GetDate(object  strDt)
        {
            DateTime dt1;
            if (DateTime.TryParse(strDt.ToString(), out dt1))
            {
                return dt1.ToString("MM/dd/yyyy");
            }
            else
            {
                return "";
            }
        }`
