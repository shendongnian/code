    if (textBox1.Text != "")
    {
        try
        {
            Convert.ToInt32(textBox1.Text);
        }
        catch
        {
            /*
            Characters were entered, thus the textbox's text cannon be converted into an integer.
            Also, you can include this line of code to notify the user why the text is not being converted into a integer:
            MessageBox.Show("Please enter only numbers in the textbox!", "PROGRAM NAME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            */
        }
    }
    /*
    else
    {
        MessageBox.Show("Please enter numbers in the textbox!", "PROGRAM NAME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);     
    }
    */
