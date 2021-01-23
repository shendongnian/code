    var radioButtons = new List<RadioButtonList>() 
    {
        RadioButtonList1,
        RadioButtonList2,
        RadioButtonList3,
        RadioButtonList4,
    };
    foreach(RadioButtonList rbl in radioButtons) 
    {
        if (rbl.SelectedValue == "1")
        {
            value1++;
        }
        else if (rbl.SelectedValue == "2")
        {
            value2++;
        }
    }
