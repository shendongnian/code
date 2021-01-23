    void Main()
    {
        // Create the list
        var items = Enumerable.Range(1, 10)
                              .Select (index => new Holder {
                                                   Name = "Info " + index,
                                                   SortOrder = index
                                                   }
                                      )
                              .ToList();
    
        //set sort order
        items.Skip(7)
             .ToList()
             .ForEach(itm => itm.SortOrder = itm.SortOrder * -1);
    
        // Now sort
        var sorted = items.OrderBy (itm => itm.SortOrder);
    
        sorted.Dump();
    
    /* Output
    Name SortOrder
    Info 10 -10
    Info 9 -9
    Info 8 -8
    Info 1 1
    Info 2 2
    Info 3 3
    Info 4 4
    Info 5 5
    Info 6 6
    Info 7 7
    */
    }
    
    // Define other methods and classes here
    
    public class Holder
    {
        public string Name   { get; set; }
        public int SortOrder { get; set; }
    }
