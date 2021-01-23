    class TypedItem
    {
       public int ID {get;set;}
       public int ParentID {get;set;}
       public List<TypedItem> Children {get;set;}
       public TypedItem()
       {
           Children = new List<TypedItem>();
       }
    }
