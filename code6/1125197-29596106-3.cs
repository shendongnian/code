    private void button1_Click(object sender, EventArgs e)
    {
        Form1 f1 = (Form1)this.Owner;//Get the Owner form
        f1.PassName = richTextBox1.Text;
        f1.PassLastName = richTextBox2.Text;
        f1.PassAge = comboBox1.Text;
        f1.PassGender = richTextBox3.Text;
        //f1.ShowDialog();
        f1.Show();
        this.Close();
    }
