    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        CheckBox cb1 = (CheckBox)Gridview.Rows[index].FindControl("myCheckBox");
        string checkboxstatus;
        if (cb1.Checked)
        {
          //write your code
        }        
        else
        {
          //write your code
        }
    }
