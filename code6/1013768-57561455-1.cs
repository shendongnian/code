abstract class SomeBase
{
    public SomeObject obj { get; protected set; }
    protected SomeBase()
    {
        obj = (SomeObject)Activator.CreateInstance(typeof(SomeObject), this); // "this" here is SomeDerived object
    }
}
class SomeDerived : SomeBase
{
    public SomeDerived()
    {
    }
}
class SomeObject
{
    public SomeObject(SomeDerived obj)
    {
        if (obj.obj == null)
        {
            // You have the reference to SomeDerived here
            // But its properties are not yet initialized (both SomeDerived and SomeBase constructors are in the progress of execution)
            // So you should not access them in the SomeObject class constructor
        }
    }
}
