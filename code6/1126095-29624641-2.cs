    try this,   
    
     string line;
        string pattern = "([0-9]{1,2})/([0-9]{2})/([0-9]{4})";
        string replacement = "$3 $2 $1";
        
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        while ((line = file.ReadLine()) != null)
        {
           Regex rgx = new Regex(pattern);
          if (rgx.Matches(line).Count > 0)
          {
           var s = rgx.Matches(line)[0].ToString(); 
           var parts = s.Split(new[] {'/'});
           if (parts[0].Length == 1)
            {
                replacement = "$3 $2 0$1";
            }
          }
           string result = rgx.Replace(line, replacement);
           all += result + "\r\n";
           richTextBox1.Text += result + "\r\n";
        }
