    private double Value1
    {
        get
        {
            double result;
            if (!double.TryParse(textBox1.Text, out result))
                throw new Exception("Couldn't parse the first text box!");
            return result;
        }
    }
    private double Value2
    {
        get
        {
            double result;
            if (!double.TryParse(textBox2.Text, out result))
                throw new Exception("Couldn't parse the second text box!");
            return result;
        }
    }
