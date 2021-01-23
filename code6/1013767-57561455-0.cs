abstract class SomeBase<TSomeObject>
    where TSomeObject : new()
{
     public SomeObject obj { get; protected set; } 
     protected SomeBase()
     {
           obj = new TSomeObject(this); // "this" here is SomeDerived object
     }
}
public class SomeDerived : SomeBase<SomeObject>
{
}
