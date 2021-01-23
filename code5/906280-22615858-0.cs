    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            var sr = new System.IO.StreamReader("C:\\" + textBox1.Text + "\\login.txt");
            username = sr.ReadLine();
            password = sr.ReadLine();
            email    = sr.ReadLine();
           
            sr.Close();
          
            if  (username == textBox1.Text && password == passwordtextbox.Text)
            {
                MessageBox.Show("You are now successfully logged in.");
            }
            else 
            {
              MessageBox.Show("Username or Password seems invalid, please use email to recover password/username");
              Form2 frm = new Form2();
              frm.Show();
              frm.mypass = password;
              frm.myid = username;  
            }
        }
        catch(System.IO.DirectoryNotFoundException)
        {
            MessageBox.Show("Error, please correct username/pass or recover");
        }
    }
