    int value;
    string path = null;
    private void button1_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        if (fbd.ShowDialog(this) == DialogResult.OK)
        {
            MessageBox.Show(fbd.SelectedPath);
            path = fdb.SelectedPath;
            
        }
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        value = Convert.ToInt32(textBox1.Text);//store the value from the textbox in variable "value"
    }
    private void button2_Click(object sender, EventArgs e)
    {
        if (path != null && Directory.Exists(path))
            for(int i=0;i<value;i++)
                Directory.CreateDirectory(Path.Combine(path,string.Format("SomeFolder{0}",i)));
    }
