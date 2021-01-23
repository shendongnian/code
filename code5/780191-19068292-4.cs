    public void button_Click() {
        try {
            ProcessFile(textBox.Text); // throwns an exception if the file didn't exist
        } catch(Exception ex) {
            MessageBox.Show(GetUserMessage(ex));
            return;
        }
    }
