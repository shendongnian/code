    int v = 0;
    for (int i = 15; i >= 0; i--)
    {
       if (b[i] == true)
       {
           Console.Write(1);
           v += (int)Math.Pow(2, i);
       }
       else
       {
           Console.Write(0);
       }
    }
