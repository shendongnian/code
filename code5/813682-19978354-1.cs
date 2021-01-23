    int min = 1, max = 50000;
    if (val-3 > min)
       Console.WriteLine(min);
    for (int i = Math.Max(min, val-3); i <= Math.Min(max, val+3); i++)
       Console.WriteLine(i);
    int last = -1;
    for (int i = 10; ; i *= 10)
    {
       int next = (val+3 + i) / i * i;
       if (next > max)
          break;
       // prevent printing something like 90, 130, 100, 500 (100 won't print)
       if (next > last)
          Console.WriteLine(next);
       next += 4*i;
       if (next > max)
          break;
       Console.WriteLine(next);
       last = next;
    }
