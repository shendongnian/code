    protected void gvDoctorList_RowCommand(object sender, GridViewCommandEventArgs e)
            {
    
                if (e.CommandName == "Select")
                {
                    int pID = Convert.ToInt32(e.CommandArgument);
                    Session["PatientId"] = Convert.ToString(e.CommandArgument);
                    //Server.Transfer("Patientstaticformatrix.aspx");
                    GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                    hdnRowIndex.Value = gvr.RowIndex.ToString();
    ... ... ...     ... ... ...     ... ... ...     ... ... ...     ... ... ... 
