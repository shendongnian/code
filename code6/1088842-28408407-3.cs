    double[] dcurrency = { 1, 1.13, 1.52 }; // Currency conversion to USD (By order: USD, EUR, GBP)
    double[] currency = { 1, 0.88, 0.66 }; // Currency conversion from USD (By order: USD, EUR, GBP)
    string[] currencies = { "USD", "EUR", "GBP" };
    public Form1()
    {
        InitializeComponent();
        comboBox1.Items.AddRange(currencies);
        comboBox2.Items.AddRange(currencies);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
        {
            textBox2.Text = "ERROR";
            return;
        }
        try
        {
            double c1 = Double.Parse(textBox1.Text);
            textBox2.Text = (c1 * dcurrency[comboBox1.SelectedIndex] * currency[comboBox2.SelectedIndex]).ToString();
        }
        catch { textBox2.Text = "ERROR"; }
    }
    
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
        {
            ((ComboBox)sender).SelectedIndex = -1;
            textBox2.Text = "ERROR";
            return;
        }
        if(comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1)
            button1_Click(button1, e);
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1)
            button1_Click(button1, e);
    }
