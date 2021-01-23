     static void Main(string[] args)
        {
            Console.WriteLine("Write your Name of Disc");
            //You need to add :\ to make it a fullPath
            string myDisc = Console.ReadLine()+":\\";
            
            Console.WriteLine("Write your Directory");
            string myDir1 = Console.ReadLine();
            
            
            string myPath =  Path.Combine(myDisc , myDir1);
            Console.WriteLine(myPath);
            string[] filePaths = Directory.GetFiles(myPath);
            foreach (var files in filePaths)
            {
                Console.WriteLine(files);
            }
            Console.ReadLine();
        }
