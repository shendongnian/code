    double tb4, tb5;
    if(double.TryParse(textBox2.Text, out tb4) && double.TryParse(textBox3.Text, out tb5))
    {
        // Do math here, since tb4 and tb5 are valid
    }
    else
    {
        // Well, something went wrong...
        label8.Text = "Could not parse values."
    }
