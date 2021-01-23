    var oldDate = new DateTime(2002, 7, 15);
    var newDate = new DateTime(2014, 9, 16, 12, 3, 0);
    // Difference
    var ts = newDate - oldDate;
    var dm = ts.Minutes;        //3
    var dh = ts.Hours;          //12
    var dd = ts.GetDays();      //2
    var dM = ts.GetMonths();    //2
    var dY = ts.GetYears();     //12
