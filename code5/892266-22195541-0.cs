    private void btnSubmit_Click(object sender, EventArgs e)
        {
             {
                string username = "Tim";
                string password = "Hennings";
                string outputMessage = string.Empty;
                if (this.txtUsername.Text != username)
                {
                    outputMessage = "Username incorrect";
                }
                if (this.txtPassword.Text != password)
                {
                    outputMessage = "Password incorrect";
                }
                if (!string.IsNullOrEmpty(outputMessage)) 
                {
                    MessageBox.Show(outputMessage);
                }
                else
                {
                    // Password and Username matched so log them in.
                }
                
            }
        }
