        Console.Write("Type number 1:");    float a = float.Parse(Console.ReadLine());
        Console.Write("Type number 2:");    float b = float.Parse(Console.ReadLine());
        Console.Write("Type number 3:");    float c = float.Parse(Console.ReadLine());
        Console.Write("Type number 4:");    float d = float.Parse(Console.ReadLine());
        Console.Write("Type number 5:");    float e = float.Parse(Console.ReadLine());
        float max = a;
        if (a < b)
        {
            max = b;
        }
        if (max < c)
        {
            max = c;
        }
        if (max < d)
        {
            max = d;
        }
        if (max < e)
        {
            max = e;
        }
        Console.WriteLine(max);
