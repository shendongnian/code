    using (StreamReader reader = new StreamReader(@"C:\Users\lorenzov\Desktop\gi_pulito_neg.txt"))
    using (StreamWriter writer = new StreamWriter(@"C:\Users\lorenzov\Desktop\gi_tradotto_neg.txt"))
    {
    
        string line = reader.ReadLine();
        while(line != null)
        {
           System.Threading.Thread.Sleep(800);
           string ris = traduttore.traduci(targetLanguage, line);
        
           writer.WriteLine(ris);
        
           line = reader.ReadLine();
        }
    
    }
