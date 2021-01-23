    int count = 0; //index of item tobe hidden
    foreach (ListViewDataItem item in ListView1.Items)
    {
        var rbl = (RadioButtonList)item.FindControl("rblSelect");
        var selectedValue = int.Parse(rbl.SelectedItem.Value);
        var selectedText = rbl.SelectedItem.Text;
        var selectedIndex = rbl.SelectedIndex;
        
        if(count == 0)
           rbl.Attributes.CssStyle.Add("visibility", "hidden");
        count++;
    }
