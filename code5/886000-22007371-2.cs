    private void ValueTextBox_TextChanged(object sender, EventArgs e)
    {
        StreamWriter writer = File.AppendText(FileNameTextBox.Text);
        writer.WriteLine(ValueTextBox.Text);
        writer.Close();
    }
