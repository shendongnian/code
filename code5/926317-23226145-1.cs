    using System.IO;
    
    List<string> Column2 = new List<string>();
    List<string> Column12 = new List<string>();
    List<string> Column45 = new List<string>();
    
    int count=0;
    foreach(var line in File.ReadLines("filepath.txt"))
    {
      if(count == 0)
      {
        continue;
      }
      else
      {
       Column2.Add(line.Split("\t")[1]);
       Column12.Add(line.Split("\t")[11]);
       Column45.Add(line.Split("\t")[44]);
       count++;
      }
    }
