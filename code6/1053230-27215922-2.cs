        public double Add(double number) { return 0;}
        public double Remove(double number) { return 0; }
        public void Example()
        {
            //Array of methods
            var methods = new Func<double, double>[]
            {
                n => Add(n),
                n => Remove(n)
            };
            //Invoking methods
            var number = 0d;
            foreach (var method in methods)
            {
                method(number);
            }
        }
