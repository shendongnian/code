    private void ComparePasswordsAndSetControlsAccordingly() {
            Color backgroundColor = SystemColors.ControlLightLight;
            if (txtPassword.Text.Length == 0 && txtPasswordAgain.Text.Length == 0) {
                // both are empty
                lblPWCountAgain.Visible = false;
                // background color is default
                lblPasswordCount.Text = "???"; // set the text to be displayed
                lblPWCountAgain.Text = "???";  // set the text to be displayed ( or leave it out : it's not visible anyway )
            }
            else if (txtPassword.Text == txtPasswordAgain.Text) {
                // they match
                lblPWCountAgain.Visible = true;
                lblPasswordCount.Text = "Passwords Match";
                lblPWCountAgain.Text = "Passwords Match";
                backgroundColor = Color.LightGreen;
            }
            else {
                // they do not match ( one can be empty, but not both )
                lblPWCountAgain.Visible = true;
                lblPWCountAgain.Text = "Passwords do not match!";
                lblPasswordCount.Text = "???"; // set the text to be displayed
                DisplayCharactersRemaining();
                backgroundColor = Color.Red;
            }
            txtPassword.BackColor = backgroundColor;
            txtPasswordAgain.BackColor = backgroundColor;
        }  
