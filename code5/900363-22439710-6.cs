    private Color[] sequence;
    //Declare dictionary
    private Dictionary<char,Color>  stringTocolor = new Dictionary<char,Color>();
    
    public SimonSays ()
    {
        //add content to Dictionary
        stringTocolor.Add('R', Color.Red);
        stringTocolor.Add('G', Color.Green);
        stringTocolor.Add('B', Color.Blue);
        stringTocolor.Add('Y', Color.Yellow);
    
        Color[] colourset = newSequence(textBox1);
    }
    
    public Color[] newSequence(TextBox textBox)
    {
        int length = textBox.Text.Length;
        Color[] array = new Color[length];
        //check dictionary has the char key or not
        for (int i = 0; i < length; i++)
        {
            if (stringTocolor.ContainsKey(textBox.Text[i]))
            {
                 array[i] = stringTocolor[textBox.Text[i]];
            }
            //give alert if wrong key
            else
            {
                 MessageBox.Show("Wrong Colour input at index " + i + " of textbox string!");
            }
        }
        this.sequence = array;
        return array;
    }
