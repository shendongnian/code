    public void button_Click() {
        if(!File.Exists(textBox.Text)) {
            MessageBox.Show("Could not find the file");
            return;
        }
        ProcessFile(textBox.Text); // would have thrown an exception if the file didn't exist
    }
