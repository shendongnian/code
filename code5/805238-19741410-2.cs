    using (var rdr = new StreamReader(@"C:\Users\Gebruiker\Desktop\text.txt"))
    {
         while (!(rdr.EndOfStream))
         {
             var line = rdr.ReadLine();
             if (!(line.Contains("word")) && (line != String.Empty))
             {
                 Console.WriteLine(line);
             }
         }
    }
    Console.ReadKey();
