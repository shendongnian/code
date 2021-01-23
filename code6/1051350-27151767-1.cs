     if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
     {
    	e.Handled = true;
     }
     else
     {   // only allow one decimal point
    	if ((e.KeyChar == '.'))
    	{
    		if (((TextBox) sender).Text.Contains("."))
            {
    			e.Handled = true;
            }
        }
        else
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
                        
            if (!char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("You cannot type letters!");
            }
        }
     }
