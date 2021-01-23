        int tempValue;
        String FloorNumber = textBox1.Text;
        if(!Int32.TryParse(textBox2.Text, out tempValue)
        {
             MessageBox.Show("Need a valid number for RebarCover");
             return;
        }
        int RebarCover = tempValue;
        
        // and same code for the other textboxes that you need to convert to a Int32
        ....                   
