    if (temp.StartsWith(@"/*")) {}
    else if (temp.EndsWith(@"/*")) 
    {
       sting pre = temp(1,temp.find());
       _list.Add(pre);
    }
    else                
    {
       _list.Add(temp);
    }
