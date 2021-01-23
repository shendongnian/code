    var values = new List<double>();
    for (int i = 0; i < jury; i++)
    {
        double current;
        if (double.TryParse(Console.ReadLine(), out current))
        {
           values.Add(current);
        }
        else
          i--;
    }
