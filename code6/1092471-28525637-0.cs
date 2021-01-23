     //Initialize variables
        static Random rnd;
        static StreamReader reader;
        static List<string> list;
      //here we load the text file into a stream to read each line
            using (reader = new StreamReader("TextFile1.txt"))
            {
                string line;
                list = new List<string>();
                rnd = new Random();
                int index;
                //read each line of the text file
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    //add the line to the list<string>
                    list.Add(line);
                }
                //pull 5 lines at random and print to the console window
                for (int i = 0; i < 5; i++)
                {
                    index = rnd.Next(0, list.Count);
                    Console.WriteLine(list[index]);
                }
            }
            Console.ReadKey();
          
