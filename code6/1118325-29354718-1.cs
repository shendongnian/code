     protected void btnSubmit_Click(object sender, EventArgs e)
            {
                Regex regularExpression = new Regex(@"^[0-6]$");
                
                if (regularExpression.IsMatch(tbForValidation.Text))
                {
                    //Is matching 0-6
                }
                else
                {
                    //Is not matching 0-6
                }
            }
