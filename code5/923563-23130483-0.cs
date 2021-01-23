    string[] MySplit(string input)
    {
       List<string> results = new List<string>();
       int count = 0;
       string temp = "";
       foreach(char c in input)
       {
          temp += c;
          count++;
          if(count == 3)
          {
             result.Add(temp);
             temp = "";
             count = 0;
          }
       }
    
       if(temp != "")
          result.Add(temp);
       
       return result.ToArray();
    }
