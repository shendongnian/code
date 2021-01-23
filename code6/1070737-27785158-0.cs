    protected void gv_patientMeds_onRowDataBound(object sender, GridViewRowEventArgs e)
            {   //Get data row view
                DataRowView drview = e.Row.DataItem as DataRowView;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Find dropdown control
                    Button btn= (Button)e.Row.FindControl("lb_editPatient");
                    
                    
                    if (Convert.ToInt32(drview["recordId"]) != 0)
                    { 
                        btn.CssClass= "btn-active"; 
                    }
                    else 
                    { 
                        btn.CssClass= "btn-inactive"; 
                    }
                }
            }
