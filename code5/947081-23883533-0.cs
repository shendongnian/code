    string mystring = "A\nB\nC\nD\nE\nF\nG\n";
    var str = mystring
               .Select((value, index) => new { Index = index, Value = value })    // insert Index    
               .GroupBy(i => (int)(i.Index / 5))                                  // group by index / 5
               .Select(value => String.Join("",value.Select(temp => temp.Value))) // create string out of grouped chars
               .Aggregate((a,b) => a + "|" + b);                                  // create one string out of splitted chars 
                                                                                  // and join the "|"-string in between
