    protected  void someMethod(object sender, EventArgs e)
            {
                foreach (GridViewRow item in GridView5.Rows)
                {
                    CheckBox chk = (CheckBox)item.FindControl("FolderCheckBox");
                    if (chk.Checked == true)
                    {
                        
                        string probname = chk.Text;
                    }
    
                }
            }
