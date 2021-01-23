            for (int j = 0; j < 100; j++)
            {
                DateTime dtStart = DateTime.Now;
                Test[] pTest = new Test[1000000];
                for (int i = 0; i < 1000000; i++)
                {
                    pTest[i].array = new object[10];
                }
                TimeSpan span = DateTime.Now.Subtract(dtStart);
                Console.Out.WriteLine(span.TotalMilliseconds);
                dtStart = DateTime.Now;
                Test2[] pTest2 = new Test2[1000000];
                for (int i = 0; i < 1000000; i++)
                {
                    pTest2[i] = new Test2();
                }
                span = DateTime.Now.Subtract(dtStart);
                Console.Out.WriteLine(span.TotalMilliseconds);
                dtStart = DateTime.Now;
                Test3[] pTest3 = new Test3[1000000];
                for (int i = 0; i < 1000000; i++)
                {
                    pTest3[i] = new Test3();
                }
                span = DateTime.Now.Subtract(dtStart);
                Console.Out.WriteLine(span.TotalMilliseconds);
                Console.Out.WriteLine("=============================");
            }
    Results:
    Struct = 252.2253
    int = 396.9113
    no int = 262.9782
    
    Struct = 266.8878
    int = 399.845
    no int = 473.181
    
    Struct = 313.7979
    int = 446.8496
    no int = 411.5755
    
    Struct = 364.6454
    int = 389.0763
    no int = 553.3433
    
    Struct = 298.1766
    int = 424.2794
    no int = 441.8867
