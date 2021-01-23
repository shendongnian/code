            static void Main(string[] args)
        {
            //definition of variables
            Variable[] a1 = new Variable[5];
            Variable[] a2 = new Variable[5];
            //fill the variables
            for (int i = 0; i < 5; i++)
            {
                a1[i] = new Variable(i, i* 2, i*3);
                a2[i] = new Variable(i + 5, (i+ 5) * 2, (i+5) * 3);
            }
            //define combination
            Variable[] a3;
            //join arrays
            a3 = a1.Union(a2).ToArray();
            //inefficient print
            Console.WriteLine(a3[0].a + "");
            //change original array
            a1[0].a = 10;
            //inefficient print
            Console.WriteLine(a3[0].a + "");
            Console.ReadKey();
        }
