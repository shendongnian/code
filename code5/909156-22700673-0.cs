    public async Task ReadFile()
     {
       var str = Application.GetResourceStream(new Uri("MACAddresses.txt", UriKind.Relative));
       List<string> lines = new List<string>();
       using (StreamReader r = new StreamReader(str.Stream))
       {
          string line;
          while ((line = r.ReadLine()) != null)
          {
            if(line.Contains(Suspect.Text))
             {
               lines.add(line);
             }
           }
       }
       foreach (string output in lines)
       {
         await Task.Delay(1000);
         results.items.add(output);
       }
     }
