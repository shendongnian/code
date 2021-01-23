        static void Main(string[] args)
        {
            String example1 = "There was severe to critical aortic stenosis.";
            String example2 = "He had a severe allergy when admitted but was diagnosed with aortic stenosis.";
            // {m,n} words
            Regex reg = new Regex("severe (\\w* ){0,6}aortic stenosis");
            Console.WriteLine(reg.ToString());
            Match m1 = reg.Match(example1);
            Match m2 = reg.Match(example2);
            
            Console.WriteLine(m1.Success);
            Console.WriteLine(m2.Success);
            Console.ReadLine();
        }
