    double a;
    bool success = double.TryParse(textBox1.Text, out a);
    if (success)
    {
        if (radioButton1.Checked == true)
        {
            label4.Text = ConvertToCel(a).ToString();
        }
        else if (radioButton2.Checked == true)
        {
            label3.Text = ConvertToFar(a).ToString();
        }
        else
        {
            label4.Text = "Please select an option from above";
        }
    }
    else
    {
        label4.Text = "The value could not be convered to a number.";
    }
