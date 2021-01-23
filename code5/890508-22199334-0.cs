        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            // Read the file(your SXA file) and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\SXA63.txt");
            while((line = file.ReadLine()) != null)
             {         //File to write lines which contain Rel. 
                       using(StreamWriter writer = new StreamWriter("c:\\Relfile.txt",true))
                        {
                           if(line.Contains("Rel"))
                          writer.WriteLine(line);
                        }
                counter++;
            }
            String last = File.ReadLines(@"C:\Relfile.txt").Last();
            string buildNo = last.Substring(0, 4);
            file.Close();
            Console.ReadKey();
        }
    }
