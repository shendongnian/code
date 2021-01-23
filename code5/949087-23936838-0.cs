    // return MaxValue if int cannot be parsed: this will put the garbage strings t the end of the list
    int Parse(string s)
    {
     int result;
     if(!int.TryParse(s, out result))
       return int.MaxValue;
     return result;
     }
    mylist = mylist.OrderByDescending(i => Parse(i.Size)).ToList();
