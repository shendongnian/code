    public class Testing {
        // this is the signature of the method we'd like to use to calculate.
        public delegate int Calculator(int a, int b);
        public Calculator Calc { get; set; }
        public Testing() {
            this.Calc = (x, y) => {
                throw new Exception("You haven't set a calculator!");
            };
        }
        public Testing(Calculator calc) {
            this.Calc = calc;
        }
        public int CalcWithOne(int x) {
            return Calc(1, x);
        }
    }
