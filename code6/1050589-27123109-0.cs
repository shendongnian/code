        public void test(int? x){
            if (x == null)
            {
                Console.Write("test");
            }
        }
        public void testA(int? x = null)
        {
            if (x == null)
            {
                Console.Write("test");
            }
        }
        static void Main(string[] args)
        {
            var p = new Program();
            p.test(null);
            p.testA();
        }
