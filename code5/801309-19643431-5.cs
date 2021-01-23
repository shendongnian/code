        //////////////////////////////////////////////////////////////////////
		//in your main code:
		if (!isValidHour(textBox1.Text))
			MessageBox.Show("Value for field must be a number from 1 to 24");
        if (!isValidHour(textBox2.Text))
			MessageBox.Show("Value for field must be a number from 1 to 24");
		//////////////////////////////////////////////////////////////////////
	
		///method to validate if text field is an INT from 1 to 24	
		bool isValidHour (string stringToValidate)
		{
			//make sure that we have a valid number in the text box with no other characters       
			//loop through the string, examining each character
			for (int i = 0; i < stringToValidate.Length; i++)
			{
				//if this character isn't a number, then don't close the form or continue           
				if (!char.IsNumber(stringToValidate[i]))
				{
					//MessageBox.Show("Value for 'txtHour' must be a number from 1 to 24");
					return false;
				}
			}
			//now that we know we have a valid number, convert the string to int and make sure it's not less than 1 or greater than 24
			int testInt = Convert.ToInt32(stringToValidate);
			if (testInt < 1 || testInt > 24)
			{
				//MessageBox.Show("Value for 'txtHour' must be a number from 1 to 24");
				return false;
			}
			
			return true;
		}
