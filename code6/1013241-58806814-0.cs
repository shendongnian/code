    private void Form_ResizeEnd(object sender, EventArgs e)
    {
        foreach(ComboBox comboBox in parentControl.Controls.OfType<ComboBox>
        {
            comboBox.SelectionLength = 0;
        }
    }
