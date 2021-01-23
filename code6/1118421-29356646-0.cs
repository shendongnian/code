    string input = textBox1.Text;
    try
    {
        int Output = Convert.ToInt32(input, 16);
        textBox2.Text = Output.ToString();
    }
    catch (FormatException)
    {
        MessageBox.Show("Input string is not in the correct format.");
    }
    catch (OverflowException)
    {
        MessageBox.Show("Input is too large for conversion.");
    }
    //Textbox1 is Input
    //Textbox2 is Output
