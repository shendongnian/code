    int[] xValues = { }; //declaring empty array
    
    private void comboBox1_SelectedValueChanged(object sender, EventArgs e) //using selection
                                                                            //to set the xValues
    {
          if (comboBox1.SelectedIndex == 0)
        {
            xValues= { 1, 2, 3, 4, 5 };
    
        }
        else if (comboBox1.SelectedIndex == 1)
        {
           xValues = { 6, 7, 8, 9, 10 };
    
        }
        else if (comboBox1.SelectedIndex == 2)
        {
            xValues = { 11, 12, 13, 14, 15 };
    
        }        
    }
