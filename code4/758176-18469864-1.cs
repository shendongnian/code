    for (int i = 0; i < GridView8.Rows.Count; i++)
            {
                if (GridView8.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    Button objBtn = (RadioButton)grdView.Rows[i].FindControl("optGar2");  
                    Response.Write(rb.Checked);                   
                }
            }
