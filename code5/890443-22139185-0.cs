            object x1 = new StringBuilder("").ToString().ToArray();
            object y1 = new StringBuilder("").ToString().ToArray();
            Console.WriteLine(x1 == y1); //true
           
            Console.WriteLine("Address x1:" + Get(x1));
            Console.WriteLine("Address y1:" + Get(y1));
                                    
            var k = "k";
            //string.intern(k); // doesn't help
            object x = new string(k.ToArray());
            object y = new string(k.ToArray());
            Console.WriteLine(x == y); //false
           
            Console.WriteLine("Address x:" + Get(x));
            Console.WriteLine("Address y:" + Get(y));
                       
            Console.Read(); 
