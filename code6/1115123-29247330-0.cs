    public class CustomList: List<SomeType>{
    
     SomeType myList;
    
     public CustomList(SomeType list){
      myList = list;
      this.Add(list);   // you are aware of the terrible name of the argument here right?  "list" is a singular object, not a list/collection.
     }
    
    //some methods
    }
