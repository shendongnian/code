    protected void ImageButton_enable_Click(object sender, ImageClickEventArgs e)
    {
        foreach(GridViewRow gvrow in GridView_enable.Rows)
        {
            CheckBox chk1= gvrow.FindControl("CheckBox_select") as CheckBox;
            if (chk1 != null && chk1.Checked == true)
            {
                Label lblEmail = gvrow.FindControl("Label1") as Label;
                if (lblEmail != null)
                     string email = lblEmail.Text;
            }
         }
    }
