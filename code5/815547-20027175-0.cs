    var list = richTextBox1.Text
        .Split(new[] { Environment.NewLine },
            StringSplitOptions.RemoveEmptyEntries)
        .Sort();
    richTextBox2.Text = string.Join(Environment.NewLine, list.ToArray());
