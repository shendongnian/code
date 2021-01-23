    private void btn_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        displayName(button.Name);
        displayText(button.Text);
    }
    private int displayName(string name)
    {
        MessageBox.Show(name);
        return 0;
    }
    private int displayText(string text)
    {
        MessageBox.Show(text);
        return 0;
    }
