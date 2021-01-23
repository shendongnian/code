    public void button_Click() {
        try {
            if(!File.Exists(textBox.Text)) {
                MessageBox.Show("Could not find the file");
                return;
            }
            ProcessFile(textBox.Text); // throwns an exception if the file didn't exist
        } catch(Exception ex) {
            MessageBox.Show(GetUserMessage(ex));
            return;
        }
    }
