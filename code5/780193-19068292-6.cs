    public void button_Click() {
        try {
            if(!File.Exists(textBox.Text)) {
                throw new UserException("Could not find the file");
            }
            ProcessFile(textBox.Text); // throwns an exception if the file didn't exist
        } catch(Exception ex) {
            MessageBox.Show(GetUserMessage(ex));
            return;
        }
    }
