    private void button1_Click(object sender, EventArgs e)
    {
        double answer;
        double num;
        double Filename 
        if (double.TryParse(File.ReadAllText(@"C:/temp/hinnat.txt"), out Filename)
           && double.TryParse(textBox1.Text, out num))
        {
            answer = Filename * num;
            textBox2.Text = answer.ToString();
        }
    }
