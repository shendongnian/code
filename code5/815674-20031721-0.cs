        StreamReader reader=new StreamReader("file.txt");
        int index=1;
        while(!reader.EndOfStream)
        {
            string line=reader.ReadLine();
            string []nameparams=line.Split(new string[]{"s/o"}, StringSplitOptions.None);
            Console.WriteLine("{0}|{1}------|{2}|",index,nameparams[0],nameparams[1]);
        }
        reader.Close();
