    class Program
    {
        public static void Main()
        {
            new Disposable(); // CA2000
            
            IDisposable x;
            MakeDisposable(out x);
            
            Test();
        }
        public static Disposable Test()
        {
            IDisposable z;
            var x = MakeDisposable(out z);
            var y = new Disposable(); // CA2000
            return x;
        }
        private static Disposable MakeDisposable(out IDisposable result)
        {
            result = new Disposable();
            
            new Disposable(); // CA2000
            return new Disposable(); 
        }
    } 
