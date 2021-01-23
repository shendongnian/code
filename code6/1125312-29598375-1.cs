    protected void btnSubmit_Click(object sender, EventArgs e)
    {
    	DataMember dataMember = new DataMember(txtLastName.Text, txtFirstName.Text);
    
    	lblDisplayLastNameStatus.Text = (dataMember.LastNameState ==  NameValidation.PassedValidation).ToString();
    	lblDisplayFirstNameStatus.Text = (dataMember.FirstNameState ==  NameValidation.PassedValidation).ToString();
    }
