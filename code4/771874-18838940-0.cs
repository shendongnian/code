    List<ClassA> listA = GetListA()// ...
    List<ClassB> listB = GetListA()// ...
    
    if(listB.Count % listA.Count != 0)     
          throw new Exception("Unable to match listA to listB");
 
    var datasPerHeader = listB.Count / listA.Count;
    
    for(int i = 0; i < listA.Count;i++)
    {
        ClassA header = listA[i];
        IEnumerable<ListB> datas = listB.Skip(datasPerHeader*i).Take(datasPerHeader);
        Console.WriteLine(header.ToString());
        foreach(var data in datas)
        {
              Console.WriteLine("\t{0}", data.ToString());
        } 
    }
