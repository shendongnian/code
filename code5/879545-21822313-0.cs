    String [] words;    
    int lineCount=0;
    String [] Lines=File.ReadAllLines(@"C:\Data.txt");
    for (int i=0;i<Lines.Length;i++)
    {
      words = Lines[i].Split(',');
      for (int j = 0; j < 2; j++)
      {
         GlobalDataClass.Array[i,j] = Convert.ToDouble(words[j].Trim());
      }
    }
