    void Main()
    {
        var list = new List<double> {1,2,3};
        double denominator = list.Count - 1;   
        var answer = list.OrderBy(x => x).Select(x => new VP
            {
                Value = x,
                Proportion = list.IndexOf(x) / denominator
            })
            .ToArray();
        answer.Dump();
    }
    
    public struct VP
    {
        public double Value;
        public double Proportion;
    }
