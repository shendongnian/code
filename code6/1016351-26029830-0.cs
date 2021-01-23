    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
    }
    void comboBox1_SelectedValueChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedItem.ToString() == "Teacher 1")
        {
            comboBox1.Items.Remove("Teacher 2");
        }
        else
        {
            comboBox1.Items.Remove("Teacher 1");
        }
    }
