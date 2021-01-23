    protected void btnformatric_Click(object sender, EventArgs e) {
        if (gvDoctorList.SelectedRow != null) {
            GridViewRow selectedRow = gvDoctorList.SelectedRow;
            Session["PatientId"] = selectedRow.Cells[0].Text;
            Session["firstname"] = selectedRow.Cells[1].Text;
            Session["lastname"] = selectedRow.Cells[2].Text;
            Server.Transfer("Patientstaticformatrix.aspx");
        } else {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a row.')", true);
        }
    }
