    private void Button1_Click(object sender, EventArgs e)
    {
        if(operationJustCompleted)
        {
            DisplayTextBox.Text = String.Empty;
            operationJustCompleted = false;
        }
        DisplayTextBox.Text = DisplayTextBox.Text + "1";
    }
