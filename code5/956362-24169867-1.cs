    NameValueCollection nvc = Request.Form;
    string myDate;
    DateTime yeer;
    if (!string.IsNullOrEmpty(nvc["txtBookDate"]))
    {
        myDate= nvc["txtBookDate"];
        yeer = Convert.ToDateTime(myDate);
    }
    else
    {
        yeer = new DateTime(9999, 12, 31);
    }
