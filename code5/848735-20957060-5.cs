    private void textBox_TextChanged(object sender, EventArgs e)
    {
        var emptyCounter = panel1.Controls.OfType<TextBox>().Count(txtBox => String.IsNullOrWhiteSpace(txtBox.Text));
        label1.Text = emptyCounter.ToString();
    }
