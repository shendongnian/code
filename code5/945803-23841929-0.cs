    protected void EducationFeildsList_SelectedIndexChanged(object sender, EventArgs e)
    {
      If (!IsPostback)
       {
        Label1.Text = Dropdownlist1.Selectedvalue;
       }
    }
