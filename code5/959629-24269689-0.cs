    protected void DropDownList1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
       List<string> elements; // a List containing the elements you want in the second drop own menu (you will need one for each possible set of elements)
       switch(DropDownList1.SelectedValue)
       {
           case "Colors":
             DropDownList2.Items.Clear();
             DropdownList2.Items.Add(elements);
             break;
           // And then your other cases here
       }
    }
