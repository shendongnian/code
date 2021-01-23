        bool result = Int32.TryParse(Console.ReadLine(), out number);
        while (!result)
        {
            Console.WriteLine("Error!");
            GetFactorialNumber();    // here is the problem, no communication with caller
        }
        return number;
