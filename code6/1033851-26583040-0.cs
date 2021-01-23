    string str = "cmp197_10_27_147ee7b825-2a3b-4520-b36c-bba08f8b0d87_TempDoc_197";
                
    if (Char.IsDigit(str.Last()))
    {
        string digits = new string(str.Reverse().TakeWhile(c => Char.IsDigit(c)).Reverse().ToArray());
    }
