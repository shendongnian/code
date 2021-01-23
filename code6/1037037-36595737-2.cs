    int count=0;
                //ImageButton lbtn = (ImageButton)sender;
                DoctorDAO objDoctorDAO = new DoctorDAO();
                foreach (GridViewRow  row in grd_Data.Rows)
                {
                    CheckBox chk = (CheckBox)grd_Data.Rows[row.RowIndex].FindControl("Chklist");
                    if (chk.Checked == true)
                    {
    
                        count++;
    
                    }
                }
                if (count > 0)
                {
                    foreach (GridViewRow row in grd_Data.Rows)
                    {
                        CheckBox chk = (CheckBox)grd_Data.Rows[row.RowIndex].FindControl("Chklist");
                        if (chk.Checked == true)
                        {
                            ImageButton lbtn = (ImageButton)grd_Data.Rows[row.RowIndex].FindControl("btn_Delete");
    
                             objDoctorDAO.deleteDoctor(Convert.ToInt32(lbtn.CommandArgument));
                            lbl_Msg.Text = " Doctor Deleted Successfully!!";
                        }
                    }
                }
                else
                {
                    lbl_msg3.Text = "Please Check at least one record to Delete";
                    return;
                }
            
