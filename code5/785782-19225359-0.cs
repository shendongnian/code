        static void Main(string[] args)
        {
            Program p = new Program();
            p.MainImpl();
        }
        public void MainImpl() {
            Func<string> f = null;
            Program _this = this;
            f = () => { 
                   Console.WriteLine(this == f.Target); 
                   Console.WriteLine(this == _this); return null; 
            };
            //Prints "False True"
            f();
        }
