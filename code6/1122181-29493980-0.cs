    var query = /*LINQ QUERY HERE*/;
    foreach(var g in query)
    {
        int ranges = g.Age / 5; //range in example is every 10 years starting at 16
        switch(ranges)
        {
             case 0: //0 -5
             case 1: //5 - 9
             case 2: //10-15
                 continue; //we don't care about these values
             case 3: //16-20
             case 4: //21-25
                  addToRanges("16-25",g.Count);
                  break;
             ... //etc you get the idea
         }
    }
