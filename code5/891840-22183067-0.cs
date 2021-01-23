    string[] response = input.Split(`);
    
    foreach (String str in response) {
      int splitIndex = str.IndexOf(' ');
      String num = str.Substring(0, splitIndex);  
      String desc = str.Substring(splitIndex);      
      desc.Trim();
    }
