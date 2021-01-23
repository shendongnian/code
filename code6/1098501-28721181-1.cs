     string s = "some_text or some-text or Text use text, read text or what text?";
    
     string[] arr = s.Split(' ');
    
     StringBuilder sb = new StringBuilder();
    
     foreach (string item in arr)
     {
                if (!item.ToLower().Contains("-text") && !item.ToLower().Contains("_text") && item.ToLower().Contains("text"))
                {
                    if (item.Contains("text"))
                    {
                        sb.Append(item.Replace("text", "1"));
                    }
                    else {
                        sb.Append(item.Replace("Text", "1"));
                    }
                }
                else {
                    sb.Append(item);
                }
                sb.Append(' ');
       }
    
        Console.WriteLine(sb.ToString());
    
        Console.ReadKey();
