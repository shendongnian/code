    string line = "/hello/1 /a/sdhdkd asjs /hello/2 ajhsd asjskjd skj /hello/s sajdk /hello/3 ";
    string[] lineParts = line.Split(' ');
    
    int helloPartIndex;
    int helloSuffix;
    foreach (string linePart in lineParts)
    {
          if (linePart.StartsWith("/hello/"))
          {
               helloPartIndex = line.IndexOf(linePart); //This is the index of the part in the entire line
               string[] helloParts = linePart.Split('/');
               if(helloParts != null && helloParts.Length >0)
    
               if (int.TryParse(helloParts[2], out helloSuffix))
               {
                      // Do stuff when the hello suffix is integer
               }
               else
               {
                     // This is where you have to deal with /hello/s and so on
               }
          }
    }
