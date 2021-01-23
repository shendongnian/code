    int value;
    if(Int32.TryParse(_mmdTextBox.Text, out value)
    {
        if (value > 1999)
        {
            MessageBox.Show("Value is too high");
        }
        else if(value < 0)
        {
            MessageBox.Show("Value is too low");
        }
        else
        {
            // action
        }
    }
    else
    {
        // not a number
    }
