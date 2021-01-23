    CheckBox checkBox1 = new CheckBox();
    private void Form1_Load()
    {
       checkBox1.Name = "CheckBox1";
       checkBox1.Text = "Click Me!";
       checkBox1.Click += new EventHandler(checkBox1_Click);   // Only need this if you want a click handler
       this.Controls.Add(checkBox1);
    }
    private void checkBox1_Click(object sender, EventArgs e)
    {
       MessageBox.Show("You click the check box");
    }
    private void submitButton_Click(object sender, EventArgs e)
    {
       if (checkBox1.Checked)
       {
          MessageBox.Show("Check box is checked!");
       }
    }
