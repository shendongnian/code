    void ChangeColor(object sender, EventArgs e)
    {
    	var buttonName = ((Button)sender).Name;
    	MessageBox.Show("Button {0} clicked!!! Save form data", );
    	//assume that form name can be determined from name of button being clicked
    	SaveFormToDatabase(buttonName);
    }
    
    private void SaveFormToDatabase(string formName)
    {
    	//save form specified in parameter
    }
