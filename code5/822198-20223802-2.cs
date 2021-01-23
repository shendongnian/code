    int sum = 0;
    foreach (var c in digits)
    {
       if (Char.IsNumber(c))
       {
           sum += (int)Char.GetNumericValue(c);
       }
    }
