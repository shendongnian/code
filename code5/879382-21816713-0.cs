    DropDownListMonth.DataSource = list;
    DropDownListMonth.DataBind();
    DropDownListMonth.SelectedIndex = 0;
    string selectedValue=DropDownListMonth.SelectedItem.Tostring();
    foreach (ListItem item in DropDownListMonth.Items)
    {
           int i = 0;
           string month = Convert.ToString(i);
           item.Value = month;
           i = Convert.ToInt32(month);
           i++;
           if(item.Value.Tostring()==selectedValue)
           {
             item.Selected=true;
           }
    }
