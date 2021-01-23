    protected void btnRegister_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=. ; Database=TestWebSiteDB; Integrated Security=true");
        SqlDataAdapter dap = new SqlDataAdapter("insert into Person(FirstName, LastName, NationalID) values(@Name, @Surname, @ID)", con);
        dap.InsertCommand(txtboxName.Text, txtboxFamilyName.Text,txtboxNationalCode.Text);
       
        txtboxName.Text="";
        txtboxFamilyName.Text = "";
        txtboxNationalCode.Text = "";
    }
