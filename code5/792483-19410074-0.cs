    public int Calculate()
    {
        string expression = "1 plus 1 minus 2 plus 2 minus 2 minus 5 plus 10";
        string mathExpression = expression.Replace("plus", "+").Replace("minus", "-");
        DataTable dt = new DataTable();
        var value = dt.Compute(mathExpression, "");
        return (int)value;
    }
