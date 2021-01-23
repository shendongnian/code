    class Test
    {
        public int P1 { get; set; }
        public int P2 { get; set; }
    }
    var test = new Test {P1 = 5, P2 = 3};
    ShowPropertyName(test, t => t.P1);
    ShowPropertyName(test, t => t.P2, t => t.P1);
