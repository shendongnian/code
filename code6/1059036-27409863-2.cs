        private void decryptButton_Click(object sender, EventArgs e)
        {
                string dPassphraseText = dPassphrase.Text;           
            
                bool decrypted = false;            
                try
                {
                    byte[] cipherTextBytes = Convert.FromBase64String(cipherString.Text);
                    /// your code goes here
                    if (sameKey == true)
                    {
                        //your code
                    }
                    else
                    {
                       //your code
                    }
                    
                }
                catch (FormatException ex)
                {
                      //notify the user somehow, so that he will try to enter passphrase again
                }            
        }
