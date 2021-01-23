    private bool reenter = false;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (reenter || String.IsNullOrEmpty(textBox1.Text)) return;
        var in = textBox1.Text.ToCharArray(); 
        var out = Filter(input).ToArray();
        var output = new String(out);
        if (!textBox1.Text.Equals(output))
        {
            reenter = true;
            textBox1.Text = output;
            reenter= false;
        }
    }
    private IEnumerable<char> Filter(IEnumerable<char> input)
    {
         foreach(var c in input)
           if (IsAllowed(c))
               yield return c;
    }
