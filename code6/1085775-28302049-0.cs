    class r1
    {
      public  String f1, f2, f3, f4;
        public r1(string line)
        {
            //TODO: Parse line to fields
        }
    }
    class r2
    {
        public String f1, f2, f3, f4, f5, f6;
        public r2(string p)
        {
            // TODO: Complete member initialization
        }
    }
    class r3
    {
        public String f1, f2, f3;
        public String ToString()
        {
            //TODO: Implement
            return String.Format("{0} {1} {2}", f1, f2 ,f3);
        }
    }
    class c1
    {        
        public static void main()
        {
            String path1 = "file1.txt";
            Dictionary<String, r1> file1_parsed = new Dictionary<string, r1>();
            StreamReader sr = new StreamReader(path1);
            while (!sr.EndOfStream)
            {
                String line = sr.ReadLine();
                r1 record = new r1(line);
                file1_parsed.Add(record.f2, record);
            }
            sr.Close();
            String path2 = "file2.txt";
            String path3 = "file3.txt";
            sr = new StreamReader(path2);
            StreamWriter result_file = new StreamWriter(path3);
            while (!sr.EndOfStream)
            {
                r2 record = new r2(sr.ReadLine());
                result_file.WriteLine(new r3 {
                    f1=record.f2,
                    f2=record.f4,
                    f3=file1_parsed[record.f4].f4
                });
            }
            sr.Close();
            result_file.Flush();
            result_file.Close();
        }
    }
