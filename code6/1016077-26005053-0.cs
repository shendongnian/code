        static void Main(string[] args)
        {
            subhold h = new subhold();
            h.aa = 88;
            Console.WriteLine("In main " + h.aa);
            thismethod(h);
            Console.WriteLine("In main2 " + h.aa);
            Console.WriteLine("In main3 " + h.ss);  //no ERROR
            Console.ReadKey();
        }
