    public class test
    {
        private int a { get; set; }
        private int b { get; set; }
        private int c { get; set; }
        private int d { get; set; }
        public object testWithoutA()
        {
            var test = new
            {
                this.b,
                this.c,
                this.d
            };
            return test;
        }
        public object testWithoutAAndB()
        {
            var test = new
            {
                this.c,
                this.d
            };
            return test;
        }
    }
