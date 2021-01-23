    public void read() 
    { 
        int val = 0;
        if(Int32.TryParse(textbox1.Text, out val))
        {
            //parse was successful
        }
        else
        {
            MessageBox.Show("Input string cannot be parsed to an integer");
        }
    } 
