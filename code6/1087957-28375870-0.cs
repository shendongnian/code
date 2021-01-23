    string Filename {get; set;}
    
    private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "|*.csv";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)//if user clicks on ok button that path will be copied path textbox
            {
                Filename = openFileDialog.FileName;
                UpperTextbox.Text = File.ReadAllText(name);
            }
