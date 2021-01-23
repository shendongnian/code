    private void btnOk_Click(object sender, EventArgs e)
    {
        var emptyTb = this.Controls.OfType<TextBox>()
            .Cast<Control>()
            .Union(this.Controls.OfType<RichTextBox>()
            .Cast<Control>())
            .OrderBy(tb => tb.TabIndex)
            .FirstOrDefault(tb => string.IsNullOrEmpty(tb.Text));
        if (emptyTb != null)
        {
            MessageBox.Show(emptyTb.Tag.ToString());
        }
    }
