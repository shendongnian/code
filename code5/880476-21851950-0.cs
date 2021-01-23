    //remove checked rows
            protected void btn_removeall_Click(object sender, EventArgs e)
            {
                try
                {
                    foreach (GridViewRow gr in grid.Rows)
                    {
                        CheckBox cc = (CheckBox)gr.FindControl("cbDelete");
                        if (cc.Checked == true)
                        {                  
                            string id = grid.DataKeys[gr.RowIndex].Values["ID"].ToString();                  
                            DataTable dtbill = objairwaybill.tempdelete(id, company, status);
                        }
                    }           
                }
                catch (Exception ex) { }
            }
