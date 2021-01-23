        DateTime d = new DateTime();
        string s = "CUSTOMER A DOB: 22NOV83"; // any string that contains date in <dd><3 chars of Month><YY>
        string date = s.Substring(s.IndexOfAny("0123456789".ToCharArray()),7);
        d = DateTime.Parse(date);
        Response.Write(d);
