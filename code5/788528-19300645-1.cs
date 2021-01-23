    protected void Button_Click(object sender, EventArgs e)
        {
    
    String SelectedFileIds ="";
            foreach (GridViewRow item in GridView1.Rows)
            {
                CheckBox chkIsDeletable = item.FindControl("chkIsDeletable") as CheckBox;
                HiddenField hndFileId = item.FindControl("hndFileId") as HiddenField;
                if (chkIsDeletable.Checked)
                    SelectedFileIds = hndFileId.Value + ",";
            }
            SelectedFileIds = SelectedFileIds.TrimEnd(",");
    
    }
