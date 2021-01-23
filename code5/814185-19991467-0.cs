    private void button1_Click(object sender, EventArgs e)
    {
        double temp = double.Parse(textBox1.Text);
    
        if (temp < 0)
        {
            label2.Text = "Freezing.";
        }
        else if (temp > 40)
        {
            label2.Text = "Hot.";
        }
        else
        {
            label2.Text = "Moderate.";
        }
    }
