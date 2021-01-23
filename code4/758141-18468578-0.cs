    interface INameAndQty
    {
        string Name {get;set;}
        int Qty {get;set;}
    }
    
    class object1 : INameAndQty
    {
       public string Name {get;set;}
       public int Qty {get;set;}
    }
    List<object1> listA
    
    class object2 : INameAndQty
    {
       public string Name {get;set;}
       public int Qty {get;set;}
    }
    List<object2> listB;
