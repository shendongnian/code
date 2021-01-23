    private void button1_Click(object sender, EventArgs e)
    {
        double a;  // have to declare double here as we cannot include it below as bool is a rue or false statment
        bool success1 = double.TryParse(textBox1.Text, out a); // take in value as true or false
        if (radioButton1.Checked == true)
        {
            if (success1) // check if it was parsed successful
            {
                label4.Text = ConvertToCel(a).ToString(); // now set it in label
            }
        }
        else if (radioButton1.Checked == false && radioButton2.Checked == true)
        {
            if (success)
            {
                label3.Text = ConvertToFar(a).ToString();
            }
        }
        else if (radioButton1.Checked == false && radioButton2.Checked == false)
        {
            label4.Text = "Please select an option from above";
        }
    }
