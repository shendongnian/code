    private void button9_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(this.textBox1.Text))
        {
            //Form2.ActiveForm.Text = "Please select Source Folder";
            // popup.Show("Please Select Source Folder");
            MessageBox.Show("Please Select Proper Source Folder");
            return;
        }
        else
        {
            textBox1.Enabled = false;
            button9.Enabled = false;
            button1.Enabled = false;
            // instantiate your new instance of your MyFileWatcher class.
            MyFileWatcher myWatcher = new MyFileWatcher(textBox1,listBox1 ,this);
        }
    }
