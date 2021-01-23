    public class MyClass : IEnumerable<string>
    {
       private List<string> myList;
    
       public MyClass()
       {
           myList = new List<string>();
       }
    
       public ICollection<string> MyList { get { return myList; } }
    
       IEnumerator IEnumerable.GetEnumerator()
       {
          return GetEnumerator();
       }
    
       public IEnumerator<T> GetEnumerator(){
          return myList.GetEnumerator();
       }
    }
