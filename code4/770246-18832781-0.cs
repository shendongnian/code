    private void sendButton_Click(object sender, EventArgs e)
    {
        string my_str = "my string";
        comPort1.Write(msgBox.Text); //Console.Write(msgBox.Text);
        msgBoxLog.AppendText(msgBox.Text + my_str);
    }
