    protected void btnformatric_Click(object sender, EventArgs e) {
        if (gvDoctorList.SelectedRow != null) {
            GridViewRow selectedRow = gvDoctorList.SelectedRow;
            //Create URL with Query strings to redirect to new page
            Response.Redirect("Patientstaticformatrix.aspx?parentid=" + selectedRow.Cells[0].Text + "&firstname=" + selectedRow.Cells[1].Text + "&lastname=" + selectedRow.Cells[2].Text);
        } else {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a row.')", true);
        }
    }
