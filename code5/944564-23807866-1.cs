    int i = 0;
    var x = Enumerable.Range(100, 999);
    var y = Enumerable.Range(100, 999);
    foreach (var xValue in x)
    {
        foreach (var yValue in y)
        {
            i = (xValue * yValue);
            char[] number = i.ToString().ToCharArray();
            char[] reversedNumber = i.ToString().ToCharArray();
            Array.Reverse(reversedNumber);
            if (new string(number).Equals(new string(reversedNumber)))
            {
            }
        }
    }
