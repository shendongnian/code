            int random=0;            
            bool isValidInt = int.TryParse(txtrandom.Text, out random);
            if (isValidInt)
            {
                for (int i = 0; i < random; i++)
                {
                    //other code 
                }
            }
            else
            {
                Response.Write("Please enter valid int value in textbox.");
                txtrandom.Focus();
            }
