    string[] lines = File.ReadAllLines(@"D:\TXTFILE.txt");
   
    foreach(string line in lines)
    {
          if(line.Length >= 23)
          {
              var a = line.Substring(5, 18);
          }
    }
