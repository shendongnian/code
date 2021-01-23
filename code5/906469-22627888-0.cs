    int c = (new[] { a > 5 ,a > 5 && b > 7 }).Count(x=>x);
    if (c > 0)
    {
        Print("Very well, a > 5 ");
    }
    if (c > 1)
    {
        Print("Even better, b > 7");
    }
    else
    {
        Print("I don't like your variables");
    }
