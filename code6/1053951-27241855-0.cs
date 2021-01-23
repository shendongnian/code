    if (string.IsNullOrWhitespace(textBox1.Text)) {
        MessageBox.Show("Home");
    }
    float p1;
    if (!float.TryParse(textBox1.Text, out p1)) {
        MessageBox.Show("textBox1 is not a float");
    }
