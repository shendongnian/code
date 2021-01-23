    class SuperType
    {
      ...        
    }
    class SubType : SuperType
    {
      ... 
    }
    static void DoSomethingInteresting( List<SuperType list )
    {
      List<SubType> desired = list.Select( x => x as SubType )
                                  .Where( x => x != null )
                                  .ToList()
                                  ;
      ...
    }
   
