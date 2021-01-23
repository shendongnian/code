    foreach(number in positiveNumberArray)
    {
        if (number > 50)
            Console.WriteLine("Out of Range");
        else if(number > 40)
            Console.WriteLine("Range 40-50");
        else if(number > 30)
            Console.WriteLine("Range 30-40");
        else if(number > 20)
            Console.WriteLine("Range 20-30");
        else if(number > 10)
            Console.WriteLine("Range 10-20");
        else
            Console.WriteLine("Range 0-10");
    }
