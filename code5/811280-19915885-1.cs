    // No need to convert a string to a string (Text property is already a string)
    string textinput = inputTEXT.Text;
    int intinput;
    // Do not trust the user to type an integer here... 
    // check with tryparse...
    if(Int32.TryParse(inputINT.Text, out intinput))
    {
        int n = 0;
        while (n < intinput)
        {
           output.AppendText(textinput + Environment.NewLine); 
           n++;
        }
    }
    else
       MessageBox.Show("Not an integer");
