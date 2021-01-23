    private void button1_click(object sender, EventArgs e)
    {
        var rb = this.listBox1.Controls.OfType<RadioButton>().SingleOrDefault(n => n.Checked);
        if (rb != null)
            MessageBox.Show("radiobutton: " + rb.Text);
    }
