        foreach(Control c in Controls)
        {
            if (c is TextBox) 
            {
                if (String.IsNullOrEmpty(c.Text))
                {
                    txtCompleted = false; 
                    c.Focus();  
                    MessageBox.Show(errorMessage);
                    break;
                }
            }
        }
