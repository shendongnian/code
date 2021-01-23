    void Main()
    {
        var r = new Random();
        
        int count = 200000;
        var nums = Enumerable.Range(1,count)
                                .Select(i => r.Next(500).ToString())
                                .ToList();
                                
        double sumD = nums.Sum(s => double.Parse(s));
        int sumI = nums.Sum(s => int.Parse(s));
                                
        sumD.Dump();
        sumI.Dump();
    }
