    private void textBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox == null) { return; }
        if (e.KeyCode == Keys.Back && textBox.Text.Length == 0)
        {
            // this here of course being the Form
            // Select causes the form to select the previous control in the tab order
            this.Select(true, false);
        }
    }
