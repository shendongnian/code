    private static DateTime ParseDate(string date)
        {
            PersianCalendar pc = new PersianCalendar();
            string[] arrDate = date.Split("/");
            return pc.ToDateTime(Int32.Parse(arrDate[0]), Int32.Parse(arrDate[1]), 
                Int32.Parse(arrDate[2]),0,0,0,0);
        }
