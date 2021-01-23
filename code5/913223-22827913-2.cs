    for (int i = 0; i < ParamTable.Rows.Count - 1; i++)
    {
        var textBoxValue = ((TextBox)ParamTable.Rows[i].Cells[1].FindControl("txtb_1" + i)).Text;
        var dropDownValue = ((DropDownList)ParamTable.Rows[i].Cells[2].FindControl("dlist_1" + i)).SelectedItem.Text;
    }
