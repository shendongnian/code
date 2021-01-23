    private void button1_Click(object sender, EventArgs e)
    {
        var tep = new Form3();
        if (tep.ShowDialog() == DialogResult.OK)
        {
            comboBox1.Enabled = true;
            comboBox1.Items.Add("line1");
            comboBox1.Items.Add("line2");
        }
    }
