    var rows = dropdeadGridView.Rows;
    int count = dropdeadGridView.Rows.Count;
    for (int i = 0; i < count; i++)
    {
        bool isChecked = ((CheckBox)rows[i].FindControl("chkBox")).Checked;
        if(isChecked)
        {
            //Do what you want
        }
    }
