            StreamReader sr = new StreamReader(@"TextFile1.txt");
            int i = 1;
            while (!sr.EndOfStream)
            {
                if(i > 8)
                    Console.WriteLine(sr.ReadLine ());
                sr.ReadLine ();
                i++;
            }
