    ArrayList list1 = new ArrayList(new int[] {1,2,3,4,5});
    
    ArrayList list2 = new ArrayList(new int[] {1,2,8});
    
    for (int i=0; i<list1.Count && i<list2.Count; i++)
    
    {
    
    if (!Object.Equals(list1[i], list2[i]))
    
    Console.WriteLine("Different value at index {0}.", i);
    
    }
    
    if (list1.Count > list2.Count)
    
    Console.WriteLine("list1 has more elements than list2.");
    
    if (list2.Count > list1.Count)
    
    Console.WriteLine("list2 has more elements than list1.");
    
    Console.ReadLine();
