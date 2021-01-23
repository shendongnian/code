    public abstract class BaseClass
    {
      public virtual void MyTypeMethod()
      {     
      }
    }
     public class TClass : BaseClass
     {
        public override void MyTypeMethod()
        {
           Console.WriteLine("Type method called");
        }
     }
    public class MyClass<T> where T: BaseClass
    {
        public void GetValueFromType(T value)
        {
            Console.WriteLine("Genric method called");
            value.MyTypeMethod();
        }
    }
