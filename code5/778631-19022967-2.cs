    var value = Convert.ToInt32(_mmdTextBox.Text);  //Convert to int in order to compare against an int
    if (value > 1999)
    {
         MessageBox.Show("Value is to high");
    }
    else if (value < 0)
    {
         MessageBox.Show("Value is to low");
    }
    else
    {
        //Action
    }
