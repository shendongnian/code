    private void createUser_Click_1(object sender, EventArgs e)
    {
        yourClass cl = new yourClass();
        // We defined age as an integer in our method, so we first parse (convert)
        // the text value in our textbox to an integer.
        int age;
        int.TryParse(tbAge.Text, out age);
        if (cl.NewUser(tbName.Text, age) == true)
        {
            MessageBox.Show("New user succesfully added !");
        }
        else
        {
            MessageBox.Show("An error occured !");
        }
    }
