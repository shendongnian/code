     string s = "some_text or some-text or Text use text, read text or what text?"; 
     string[] arr = s.Split(' '); // < separate by space
    
     StringBuilder sb = new StringBuilder(); // String builder instance
    
     foreach (string item in arr)
     {
                // Take to lower and check for text/Text but not _text , -Text 
                if (!item.ToLower().Contains("-text") && !item.ToLower().Contains("_text") && item.ToLower().Contains("text"))
                {
                    // Simply replace Text or text 
                    sb.Append(item.ToLower().Replace("text","1"));
                }
                else {
                    // Else simply append 
                    sb.Append(item);
                }
                sb.Append(' ');  // <= Adding space 
       }
    
        Console.WriteLine(sb.ToString()); // <= Printing the output
    
        Console.ReadKey();
