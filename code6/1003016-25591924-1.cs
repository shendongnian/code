    protected void checkBoxList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var checkBoxList = sender as CheckBoxList;
        foreach (ListItem li in checkBoxList.Items)
        {
            switch (li.Selected)
            {
                 case true:
                    //Code to handle if the ListItem is selected goes here
                    break;
                 case false:
                    //Code to handle if the ListItem is not selected goes here
                    break;
                 default:
                    break;
            }
        }
    }
