    private void button1_Click(object sender, EventArgs e)    
    {
        List<int> tab = new List<int>();
        for (int i = 0; i < numericUpDown1.Value; ++i)
        {
            tab.Add(Convert.ToInt32(Interaction.InputBox("Value", "Array")));
           // Error here
        }
        textBox1.Text = "Plus petit: " + Smaller(tab).ToString();         
        //textBox1.Text = "Plus grand: " + result.ToString();
    }
    
    private int Smaller(List<int> list)
    {
        var result = list[0];
        foreach (int tabs in list)
        {
            if (result > tabs)
            {
                result = tabs;
            }
        }
        return result;
    }
