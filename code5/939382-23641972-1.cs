    private void handleLoginButton(){
            string lietotajvards = "user";
            string parole = "user";
            if (textBox1.Text == lietotajvards && textBox2.Text == parole)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
    }
