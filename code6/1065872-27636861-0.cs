    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //Creating DataTable dt
     DataTable dt;
     if (Session["Insert"] == null) //or nothing
     {
         dt = new DataTable();
         //Creating DataTable Columns
         dt.Columns.Add("FName", typeof(string));
         dt.Columns.Add("MName", typeof(string));
         dt.Columns.Add("LName", typeof(string));
         dt.Columns.Add("Phone", typeof(string));
         dt.Columns.Add("EId", typeof(string));
         dt.Columns.Add("State", typeof(string));
         dt.Columns.Add("City", typeof(string));
         dt.Columns.Add("Country", typeof(string));
         dt.Columns.Add("PCode", typeof(string));
         dt.Columns.Add("Gender", typeof(string));
         dt.Columns.Add("AOI", typeof(string));
     }
     else
     {
        dt = Session["Insert"] as DataTable;
     }
        dt.Rows.Add(txtFN.Text, txtMN.Text, txtLN.Text, txtPhone.Text, txtEId.Text, ddlState.Text, ddlCity.Text, txtCountry.Text, txtPCode.Text, rdGender.SelectedValue, cbAOI.SelectedValue);
        //Creating Session object to store DataTable dt
        Session["Insert"] = dt;
        lblMandatory.Text = "Successfully Inserted into Database";
        System.Threading.Thread.Sleep(1000);
        Response.Redirect("Home.aspx");
    } 
