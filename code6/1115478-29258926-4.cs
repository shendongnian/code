    public string getOperand(string t, string textBox)
    {
        
        if (t.Equals(","))
        {
            textBox = textBox + t;
            change = true;
            second = double.Parse(textBox);
        }
        else if (Op.Equals(""))
        {
            textBox = textBox + t;
            if (!change)
            {
                textBox = "";
                change = true;
                textBox = textBox + t;
            }
            first = double.Parse(textBox);
        }
        else
        {
            if (!change)
            {
                textBox = textBox + t;
            }
            else
            {
                textBox = t;
                change = false;
            }
            second = double.Parse(textBox);
        }
        return textBox;
    }
