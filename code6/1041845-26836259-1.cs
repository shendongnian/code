     List<int> list = new List<int>();
    while(result.Read())
    {
     int movieID  = Convert.ToInt32(result["MovieID"]);
     list.Add(movieID);
    }
  
