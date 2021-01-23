    var s = file.ReadToEnd(yourfile);
    s.Split(new string[]{"Post to"}) // Split on post to to get an array of string with 1 string per customer
         .Select(item=>item.Split(new char[]{' '}) // split on each word so that we can find australia
               .TakeUntill(substring => substring == "Australia") // take all the words untill we find australia, then stop
               .Aggregate((a,b)=>a+" " + b)// rebuild the string by summing all those words preceeding australia
               );
