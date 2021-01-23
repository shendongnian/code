    int value;
    if(Int32.TryParse(_mmdTextBox.Text, out value)
    {
        if (value > 1999 && value < 0)
        {
             MessageBox.Show("Value is to high");
        }
    }
