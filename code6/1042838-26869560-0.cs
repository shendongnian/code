    var testCounter = "NAME0:0";
    
    
    for (int x = 0; x < 50; x++)
    {
        Match m = Regex.Match(testCounter, @"(?<label>NAME)(?<counter>\d+):(?<robinCounter>\d+)");
        if (m.Success)
        {
            var count = Int32.Parse(m.Groups["counter"].Value);
            var roundRobinCounter = Int32.Parse(m.Groups["robinCounter"].Value);
    
            count++;
    
            if (count == 46)
            {
                count = 0;
                roundRobinCounter++;
            }
    
            testCounter = String.Format("{0}{1}:{2}", m.Groups["label"].Value, count, roundRobinCounter);
            Console.WriteLine(testCounter);
        }
    }
