    int [] count = new int[6];
    foreach(number in positiveNumberArray)
    {
        if (number > 50)
            count[5]++;
        else if(number > 40)
            count[4]++;
        else if(number > 30)
            count[3]++;
        else if(number > 20)
            count[2]++;
        else if(number > 10)
            count[1]++;
        else
            count[0]++;
    }
    Console.WriteLine(" > 50: {0}", count[5]);
    Console.WriteLine("40-50: {0}", count[4]);
    Console.WriteLine("30-40: {0}", count[3]);
    Console.WriteLine("20-30: {0}", count[2]);
    Console.WriteLine("10-20: {0}", count[1]);
    Console.WriteLine("0-10: {0}", count[0]);
