    using System.Linq;
    // Holder for the data coming out of your internal for each converted
    // to a transformation function
    class ListNode
    {
       // or whatever comparable type your sort order is
       int SortOrder {get;set;}
       HttpGenericControl Li {get; set;}
    }
    
    // Convert function is your code inside the foreach returning the
    // HttpGenericControl li from each loop same code except for the return
    ListNode ConvertChildToLi(ChildClass child) 
    {
        // Same code here to the end of the for loop
        return new ListNode { SortOrder = sortOrder, Li = li };
    }
