    public class A
    {
         public void SomeMethod()
         {
              Debug.Write(string.Format("I was declared in class: {0}",this.GetType()));
         }
    }
    
    public class B : A
    {
    
    
    }
    
    var instanceOfB = new B();
    instanceOfB.SomeMethod();
