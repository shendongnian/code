    private void ToggleButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
    	//if currently tapped button is yesTBU
    	if(sender == yesTBU)
    	{
    		//set noTBU to opposite value of yesTBU
    		noTBU.IsChecked = !yesTBU.IsChecked;
    	}
    	//else if currently tapped button is noTBU
    	else
    	{
    		//set yesTBU to opposite value of noTBU
    		yesTBU.IsChecked = !noTBU.IsChecked;
    	}
    }
