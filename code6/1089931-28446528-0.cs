    private void button1_Click(object sender, EventArgs e)
    {
        int in1; // change int names to not confuse woth textboxes
        int in2;
        int in3;
    
        in1 = int.Parse(input1.Text); // input1 is textBox
        in2 = int.Parse(input2.Text);
        in3 = int.Parse(input3.Text);
    
        int sum1 = input1 * 15;
        int sum2 = input2 * 12;
        int sum3 = input3 * 9;
        
        textBox3.Text = sum1.ToString();
        textBox2.Text = sum2.ToString();
        textBox4.Text = sum3.ToString();
       
    }
