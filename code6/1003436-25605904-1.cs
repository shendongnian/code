    checked {
        double longMinValue = long.MinValue;
        var i = 0;
        while (true)
        {
            long test = (long)(longMinValue - i);
            Console.WriteLine("Works for " + i++.ToString() + " => " + test.ToString());
        }
    }
