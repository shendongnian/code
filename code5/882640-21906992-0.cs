    var date = DateTime.MinValue;
    if (DateTime.TryParse("1998/04/30", out date))
    {
        //Sucess...
        mySmallVuln.Published = date;
    }
