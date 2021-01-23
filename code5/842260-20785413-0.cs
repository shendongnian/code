     string path = C:\...\text1.text
     List<string> lines = File.ReadAllLines(path);
     int i = 1;
     foreach (var line in lines)
    {
       Console.WriteLine("{0}. {1}", i, line);
       i++;
     }
      Console.Write("Choose which line to edit: ");
      int n = int.Parse(Console.ReadLine());
      n--;
     Console.Write("{0}. ", n + 1);
    lines.Insert(n,Environment.NewLine);
    File.WriteAllLines(path, lines.ToArray()); 
