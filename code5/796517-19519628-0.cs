    public static double GetAmount(this TextBox t)
    {
        double result = 0;
        double.TryParse(t.Text, out result);
        return result;
    }
