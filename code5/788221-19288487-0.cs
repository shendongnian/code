    int num;
    string stringWithNumbers = "10a";
    if (int.TryParse(Regex.Replace(stringWithNumbers, @"[^\d]", ""), out num))
    {
        //The number is stored in the "num" variable, which would be 10 in this case.
        if (num >= 10)
        {
            //Do something
        }
    }
    else
    {
        //Nothing numeric i the string
    }
