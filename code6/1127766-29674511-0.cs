        private bool IsDateInThePast(string inputDate)
        {
            DateTime dt = DateTime.Parse(inputDate);
            return dt.CompareTo(DateTime.Parse(DateTime.Now.ToShortDateString())) < 0;
        }
