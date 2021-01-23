    string[] text = System.IO.File.ReadLines(@File path).Take(100).ToArray();
    
    //extDic[username] - [moviename][rating] is the structure
    
    Dictionary<string,Dictionary<string,double>> extDic=new Dictionary<string,Dictionary<string,double>>();   
    foreach(string s in text)
    {
      int rating;
       //split only once
       string[] splitted = s.Split('\t');
      //UPDATE: skip the current line if the structure is not ok
      if(splitted.Length != 3){
          continue;
      }
       
      string username=splitted[0];
      string moviename=splitted[1];
      Int32.TryParse(splitted[2], out rating);
      //UPDATE: skip the current line if the user name or movie name is not valid
      if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(moviename)){
          continue;
      }
       
       if(!extDic.ContainsKey(username)){
          //create a new Dictionary for every new user
          extDic.Add(username, new Dictionary<string,double>());
       }
       //at this point we are sure to have all the keys set up
       //let's assign the movie rating
       extDic[username][moviename] = rating;
       
    }
