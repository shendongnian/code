    private void button1_Click(object sender, EventArgs e)
        {
            if( UserNameTextbox.Text == "UserName" 
                && PasswordTextbox.Text == "password" )
            {
            GameSelect gs = new GameSelect();
            gs.ShowDialog();
            }
        }
