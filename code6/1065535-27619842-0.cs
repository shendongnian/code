    StreamReader reader = new StreamReader("C:\\Users\\lorenzov\\Desktop\\gi_pulito_neg.txt");
    string line;
    string app = "";
    int i = 0;
    
    while ((line = reader.ReadLine()) != null)
    {
       i++;
       int lunghezza = line.Length;
       
       Console.WriteLine(i);
       System.Threading.Thread.Sleep(800);
       string ris= traduttore.traduci(targetLanguage, line);
    
       // Console.WriteLine(line);
       // Console.WriteLine(ris);
       // Console.Read();
       // app = app + ris;
    
       // System.Threading.Thread.Sleep(50);
    
       File.AppendAllText(@"C:\Users\lorenzov\Desktop\gi_tradotto_neg.txt", ris + Environment.NewLine);
    }
