    IList<string> Solutions = new List<string>(5);
    Solutions.Add("The Odyssey");
    Solutions.Add("Dune");
    Solutions.Add("Sherlock Holmes");
    Solutions.Add("Othello");
    Solutions.Add("Of Mice and Men");
    
    Random ran = new Random();
    int r = ran.Next(Solutions.Count); 
    
    string s = Solutions[r];
