    List<int> l1 = new List<int> { 1, 2, 3, 4 };
    List<int> l2 = new List<int> { 3, 1, 2, 4 };
    if (l1.OrderBy(x => x).SequenceEqual(l2.OrderBy(y => y)))
    {
         Console.WriteLine("List are equal"); // will write this
    }
    if (l1.SequenceEqual(l2))
    {
         Console.WriteLine("List are equal"); 
    }
    else
    {    
         Console.WriteLine("List are not equal"); // will write this    
    }
   
    
