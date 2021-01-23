    bool autoChanged;
    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        if (!autoChanged)
        {
            //Perform actions you wish when the value is changed by the user
        }
        autoChanged = false;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        autoChanged = true; //Setting the flag to true every time the .Value property is modified via code
        numericUpDown1.Value = 5;
    }
