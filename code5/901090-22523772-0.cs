    protected void btndelete_Click(object sender, EventArgs e)
        {
            CheckBox cb;
            int[] idArr = new int[Gridview1.Rows.Count];
            int idcount = 0;
            foreach (GridViewRow row in Gridview1.Rows)
            {
                cb = (CheckBox)row.FindControl("chkdelete");
                if (cb != null)
                {
                    if (cb.Checked)
                    {
    
                        int ID = Convert.ToInt32(Gridview1.DataKeys[row.RowIndex].Values["ID"].ToString());
                        idArr[idcount] = ID;
                        idcount++;
                    }
                }
            }
            
            //Bind the gridview again...
        }
