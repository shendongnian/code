    public TextBox GetNextEmptyTextBox()
    {
        return (new[] { textBox1, textBox2, textBox3 })
            .FirstOrDefault(tb => string.IsNullOrEmpty(tb.Text));
    }
