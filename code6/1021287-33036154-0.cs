    DateTime starDate = TextToDate(txtStartDate.Text); //01/07/2013
    // or startDate = DateTimePicker1.Value;
    
    DateTime endDate = TextToDate(txtEndDate.Text);  //30/06/2014
    // or endDate = DatetTimePicker2.Value
    
    DateTime calculatedEndDate = startDate.AddYears(1).AddDays(-1);
    // 01/07/2013 .AddYears(1) ==> 01/07/2014 .AddDays(-1) ==> 30/06/2014
    
    // Note for above line:
    //     if you will be using the start date and end date in an sql query
    //     remove the call to function AddDays(-1)
    //     for display purposes, keep the function AddDays(-1)
    
    if(endDate != calculatedEndDate)
    // note: if DateTimePicker is returning time component, then you will need to compare each (year, month and day)
    {
        // show error message
    }
    else
    {
        // dates are 1 year apart.
    }
