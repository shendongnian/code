    string[] text = System.IO.File.ReadLines(@File path).Take(100).ToArray();
    
    //extDic[username] - [moviename][rating] is the structure
    
    Dictionary<string,Dictionary<string,double>> extDic=new Dictionary<string,Dictionary<string,double>>();   
    foreach(string s in text)
    {
      int rating;
       //split only once
       string[] splitted = s.Split('\t');
       
      string username=splitted[0];
      string moviename=splitted[1];
      Int32.TryParse(splitted[2], out rating);
       
       if(!extDic.ContainsKey(username)){
          //create a new Dictionary for every new user
          extDic.Add(username, new Dictionary<string,double>());
       }
       //at this point we are sure to have all the keys set up
       //let's assign the movie rating
       extDic[username][moviename] = rating;
       
    }
