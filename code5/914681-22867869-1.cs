    if (int.TryParse(outnum, out num1))
    {
        List<int> numbers = outNum.ToCharArray()
                            .Select(x => Convert.ToInt32(x.ToString()))
                            .ToList();
        if(numbers[2] == 7)
            Console.WriteLine("Is 7");
        else
            Console.WriteLine("Not 7");
    }
