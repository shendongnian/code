    if (Regions.SelectedIndex == 1)
    {
        select += " where Reg_ID = 1";
        dFacilities.Style.Add("display", "block");
    // note the number at the end of this variable 
        CheckBoxList1.Style.Add("display", "block");
    }
    if (Regions.SelectedIndex == 2)
    {
        select += "where Reg_ID = 2";
        dFacilities.Style.Add("display", "block");
    // note the number at the end of this variable 
        CheckBoxList1.Style.Add("display", "block");
    }
