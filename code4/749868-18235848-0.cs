    public class Interval
    {
        public string TheValue { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public bool InRange(int x)
        {
            return x >= this.Start && x <= this.End;
        }
    }
    public void MyMethod()
    {
        var intervals = new List<Interval>();
        // Add them here...
        var x = 3213;
        var correctOne = intervals.FirstOrDefault(i => i.InRange(x));
        Console.WriteLine(correctOne.TheValue);
    }
