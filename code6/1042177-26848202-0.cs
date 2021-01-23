    static void Main(string[] args)
    {
      using(StreamReader source = new StreamReader(filepathsource))
      {
         using(StreamWriter dest = new StreamWriter(filepathdest,false))
         {
           dest.WriteLine("Department,Number,Long Title,Description");
           string line;
           bool dept = false;
           bool num = false;
           bool title = false;
           string temp;
           while ((line = source.ReadLine()) != null)
           {
              ......
           }
        }
      }
    }
