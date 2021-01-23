    private void submit_Click(object sender, RoutedEventArgs e)
    {
    	string gender = "";
    	.......
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
    	}
    	.......
    	else
    	{
    	   var svc = new KejriwalService.aapSoapClient();
    	   svc.registerToTeamAsync(name.Text, sadd.Text, cadd.Text, 
								zip.Text, eadd.Text, phn.Text, age.Text, gender);
    	}
    }
