    private void button1_Click(object sender, EventArgs e)
    {
        UpdateChart();
    }
    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        // You might have some data validation on the TextBox.Text here, 
        // which you wouldn't need in the Button_Click event
        TextBox textbox = sender as TextBox;
        if (IsValidText(textBox.Text)) 
        {
            // Now update the chart
            UpdateChart();
        }
        else
        {
            DisplayBadTextWarning(textBox.Text);
        }
    }
