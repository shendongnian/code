    List<List<string>> ls = new List<List<string>>();
               var  filename="aa.txt";
               StreamReader sr = new StreamReader(filename);
               while (!sr.EndOfStream)
               {
                   var line = sr.ReadLine();
                   var element = line.Split(',');
                   List<string> temp = new List<string>();
                   foreach (var item in element)
                   {
                       temp.Add(item);
                   }
                   ls.Add(temp);
               }
