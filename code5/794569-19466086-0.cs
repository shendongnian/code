    public abstract class A
    {
         [XmlType]
         public void F()
         {
              InnerF();
         }
         protected abstract InnerF();
    }
  
    public class B extends A
    {
         protected void InnerF()
         {
         }
    }
