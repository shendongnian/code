    private void submit_Click(object sender, RoutedEventArgs e)
    {
    	var isValid = ValidateInput();
    	if(isValid)
    	{
    		var svc = new KejriwalService.aapSoapClient();
    		svc.registerToTeamAsync(name.Text, sadd.Text, cadd.Text, 
                                zip.Text, eadd.Text, phn.Text, age.Text, gender);
    	}
    }
    
    private bool ValidateInput()
    {
    	if (name.Text == String.Empty)
    	{
    		MessageBox.Show("Please Enter the name");
    		name.Focus();
    		return false;
    	}
    	if (age.Text == String.Empty)
    	{
    		MessageBox.Show("Please Enter the age");
    		age.Focus();
    		return false;
    	}
    	if (male.IsChecked == true)
    	{
    		gender = male.Content.ToString();
    	}
    	else if (fem.IsChecked == true)
    	{
    		gender = fem.Content.ToString();
    	}
    	else    //none of them is selected.
    	{
    		MessageBox.Show("Please select your Gender");
    		return false;
    	}
    	if (sadd.Text == String.Empty)
    	{
    		MessageBox.Show("Please Enter the Street Address");
    		sadd.Focus();
    		return false;
    	}
    	if (cadd.Text == String.Empty)
    	{
    		MessageBox.Show("Please Enter the City Address");
    		cadd.Focus();
    		return false;
    	}
    	if (eadd.Text == String.Empty)
    	{
    		MessageBox.Show("Please Enter the Email Address");
    		eadd.Focus();
    		return false;
    	}
    	if (phn.Text == String.Empty)
    	{
    		MessageBox.Show("Please Enter the Phone Number");
    		phn.Focus();
    		return false;
    	}
    	if (zip.Text == String.Empty)
    	{
    		MessageBox.Show("Please Enter the Zipcode");
    		zip.Focus();
    		return false;
    	}
    	return true;
    }
