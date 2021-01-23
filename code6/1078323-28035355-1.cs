     private void button1_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Length == 0)
        {
            MessageBox.Show("Please enter a name!");
            return;
        }
        File.AppendAllText(@"..\..\..\Files\playerdetails.txt", txtName.Text);
        MessageBox.Show("You are now ready to play");
        Form1 myForm1 = new Form1();
        myForm1.Show();
    }
