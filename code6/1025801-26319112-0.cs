    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkTest = (CheckBox)sender;
        GridViewRow grdRow = (GridViewRow)chkTest.NamingContainer;
        count = 0;
    
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("cb");
    
            if (chk.Checked)
            {
                count++;
            }
        }
    
        if (count == 3)
        {
            btn.Enabled = true;
        }
        else
        {
            btn.Enabled = false;
        }
    
        Response.Write(count.ToString() + "<br />");
    }
    
    protected void btn_Click(object sender, EventArgs e)
    {
        string strname = string.Empty;
    
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            HiddenField hiddenField = (HiddenField)gvrow.FindControl("HiddenField1");
            CheckBox chk2 = (CheckBox)gvrow.FindControl("cb");
    
            if (chk2 != null & chk2.Checked)
            {
                strname += hiddenField.Value + ","; 
                strname = strname.Trim(",".ToCharArray());
                Response.Write("Selected UserNames: <b>" + strname.ToString() + "</b><br />");
    
                string[] words = strname.Split(',');
                foreach (string word in words)
                {
                    Response.Write(word.ToString() + "<br /><br />");
                }
            }
        }
    }
