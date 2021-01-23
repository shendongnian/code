    private void CommandFileSelectButton_Click(object sender, EventArgs e)
    {
        Stream mystream;
        OpenFileDialog commandFileDialog = new OpenFileDialog();
        if (commandFileDialog.ShowDialog() == DialogResult.OK)
        {
            if ((mystream = commandFileDialog.OpenFile())!= null)
            {
                string fileName = commandFileDialog.FileName;
                CommandListTextBox.Text = fileName;
                _commandList.AddRange(System.IO.File.ReadAllLines(fileName));
                CommandListListBox.DataSource = _commandList;
            }
        }
    }
    
