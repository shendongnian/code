     string s = "some_text or some-text or Text use text, read text or what text?";
    
     string[] arr = s.Split(' ');
    
     StringBuilder sb = new StringBuilder();
    
     foreach (string item in arr)
     {
        if (!item.ToLower().Contains("-text") && !item.ToLower().Contains("_text") && item.ToLower().Contains("text"))
        {
              if (item.Contains('?'))
              {
                    sb.Append("1? ");
               }
               else {
                    sb.Append("1 ");
               }
          }
           else {
               sb.Append(item+" ");
          } 
        }
    
        Console.WriteLine(sb.ToString());
    
        Console.ReadKey();
