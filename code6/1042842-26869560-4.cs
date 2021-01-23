    var testCounter = "NAME1";
    
    
    for (int x = 0; x < 50; x++)
    {
        Match m = Regex.Match(testCounter, @"(?<label>NAME)(?<counter>\d+)(?::(?<robinCounter>\d+))?");
        if (m.Success)
        {
            var count = Int32.Parse(m.Groups["counter"].Value);
    
            var roundRobinCounter = 0;
            if (m.Groups["robinCounter"].Success)
                roundRobinCounter = Int32.Parse(m.Groups["robinCounter"].Value);
    
            count++;
            if (count == 46)
            {
                count = 1;
                roundRobinCounter++;
            }
    
            var sb = new StringBuilder();
            sb.AppendFormat("{0}{1}", m.Groups["label"].Value, count);
            if (roundRobinCounter != 0)
                sb.AppendFormat(":{0}", roundRobinCounter);
    
            testCounter = sb.ToString();
            Console.WriteLine(testCounter);
        }
    }
