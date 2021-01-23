    private void acceptButton_Click(object sender, EventArgs e)
    {
        if (comboBox1.ContainsFocus) comboBox1_Leave(acceptButton, null);
        // do accept stuff here..
    }
    private void cancelButton_Click(object sender, EventArgs e)
    {
        if (comboBox1.ContainsFocus) comboBox1_Leave(cancelButton, null);
        // do cancel stuff here..
    }
    private void comboBox1_Leave(object sender, EventArgs e)
    {
        // do leave stuff here..
        Console.WriteLine(sender);
    }
