    // split on the basis of white space
    string[] arrdate = currentLine.Split(' ');
    
    // now find out element with '/' using lambda
    string item = arrdate.Where(item => item.Contains("/")).FirstOrDefault();
    
    // if you don't want to use lambda then try for loop
    string item;
    for(int i = 0; i < arrdate.Length; i++)
    {
    if(arrdate[i].Contains("/"))
    {
    item = arrdate[i]
    }
    }
