        static void Main(string[] args)
        {
            GetFileNamesandWriteInTxt();
        }
        public static void GetFileNamesandWriteInTxt()
        {
            string path = @'X:\myfolder\photos';
            DirectoryInfo dr = new DirectoryInfo(path);
            FileInfo[] mFile = dr.GetFiles();
            StreamWriter writer = new StreamWriter("D:\\FileNames.txt", true);
            foreach (FileInfo fiTemp in mFile)
            {
                writer.WriteLine(fiTemp.Name);
                Console.WriteLine(fiTemp.Name);
            }
            Console.ReadLine();
          }
