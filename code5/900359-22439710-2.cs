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
    
        Color[] colourset = newSequence(textBox1.Text.Length);
    }
    
    public Color[] newSequence(int length)
    {
        Color[] array = new Color[length];
        //check dictionary has the char key or not
        if (stringTocolor.ContainsKey(textBox1.Text[i]))
        {
            array[i] = stringTocolor[textBox1.Text[i]];
        }
        //give alert if wrong key
        else
        {
            MessageBox.Show("Wrong Colour input at index " + i + " of textbox string!");
        }
        this.sequence = array;
        return array;
    }
