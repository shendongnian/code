     int count=0;
                    //ImageButton lbtn = (ImageButton)sender;
                    DoctorDAO objDoctorDAO = new DoctorDAO();
                    foreach (GridViewRow 
        
         1. ***List item***
        
        row in grd_Data.Rows)
                    {
                        CheckBox chk = (CheckBox)grd_Data.Rows[row.RowIndex].FindControl("Chklist");
                        if (chk.Checked == true)
                        {
        
                            count++;
        
                        }
                    }
                    if (count <= 0)
                    {
                       lbl_msg3.Text = "Please Check at least one record to Delete";
                        return; 
                    }
                    
            
