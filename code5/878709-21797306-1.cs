    if (name.Text == String.Empty)
            {
                MessageBox.Show("Please Enter the name");
                name.Focus();
                return false;
            }
    else
            {
                if(name.Text == "Name"){
                
                     MessageBox.Show("Your error message");
                     name.Focus();
                     return false;
           }
    
    }
