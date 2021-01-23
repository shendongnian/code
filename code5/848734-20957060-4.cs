    private void textBox_TextChanged(object sender, EventArgs e)
    {
        var emptyCounter = 0;
        foreach (TextBox txtBox in panel1.Controls)
        {
            if (String.IsNullOrWhiteSpace(txtBox.Text))
            {
                emptyCounter++;
            }
        }
        label1.Text = emptyCounter.ToString();
    }
