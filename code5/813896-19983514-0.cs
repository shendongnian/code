            string date = "2012-11-14T00:00:00";
            string result = DateTime.Parse(date).ToShortDateString();
            //or....
            
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Parse(date);
            //now its only use dateTime.Date
