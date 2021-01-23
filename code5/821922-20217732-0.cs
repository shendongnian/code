        private void passwordLogin_Leave(object sender, EventArgs e){
            if (passwordLogin.Text.Length == 0){
                passwordLogin.Text = "Password";
                passwordLogin.ForeColor = Color.Silver;
                passwordLogin.PasswordChar = '\0';
            }
        }
        private void passwordLogin_Enter(object sender, EventArgs e){
            if (passwordLogin.Text == "Password"){
                passwordLogin.Text = "";
                passwordLogin.ForeColor = Color.Black;
                passwordLogin.PasswordChar = '*';
            }
        }
