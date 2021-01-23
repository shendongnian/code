    class CalcResult
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Begin { get; set; }
        public int End { get; set; }
    }
    private void GetXYBeginEnd(int a, int b, out int x, out int y, out int begin, out int end)
    {
        // do stuff
        return new CalcResult { X = 23, Y = 54, Begin = 45, End = 98 };
    }
