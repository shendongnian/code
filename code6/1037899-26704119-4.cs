    public void button1_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            var files = openFileDialog1.SafeFileNames; // local variable only
            var paths = openFileDialog1.FileNames; // local variable only
            for (int i = 0; i < files.Length; i++)
            {
                listBox1.Items.Add(new FileAndPath(files[i], paths[i])); // Add songs to the listbox
            }
        }
    }
