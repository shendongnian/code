    string puretext = textBox1.Text.Replace(Environment.NewLine, ""); //Ignore newline
    for (int i = 0; i < puretext .Length; i++)
    {
        if (stringTocolor.ContainsKey(puretext [i]))
        {
             array[i] = stringTocolor[puretext [i]];
        }
        //give alert if wrong key
        else
        {
             MessageBox.Show("Wrong Colour input at index " + i + " of textbox string!");
        }
    }
