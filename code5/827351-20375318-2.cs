    void Main()
    {
    	var c = new C();
    	SetDynamic(new MyType(), c);
    	SetDynamic(new MyOtherType(), c);
    }
    
    void SetDynamic<T>(T item, C c)
    {
    	((dynamic)c).Add(item);
    }
    
    public class C
    {
       ///...
       
       public void Add(MyType item)
       {
       	    ListOfMyTypeObjects.Add(item);
       }
       
       public void Add(MyOtherType item)
       {
      	    ListOfMyOtherTypeObjects.Add(item);
       }
    }
