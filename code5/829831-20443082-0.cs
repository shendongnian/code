        using (StreamReader sr = new StreamReader("c:\\TestFile.txt"))
        {
            while (sr.Peek() >= 0) 
            {
                Console.WriteLine(sr.ReadLine());
            }
        }
