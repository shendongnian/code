    static void Main(string[] args)
    {
        // obviously you already have this
        BaseObject obj = new TestObject();
        // you know this
        var myType = obj.GetType();
        // you know the type of the base class
        var baseControllerType = typeof(BaseController<>);
            
        // make the type generic using your model type
        baseControllerType = baseControllerType.MakeGenericType(myType);
        // the baseControllerType is now Generic BaseController<TestObject>
        // reference all types in a variable for a 'cleaner' linq query expression
        var allTypes = Assembly.GetEntryAssembly().GetTypes();
        // get all types that are a sub class of BaseController<TestObject>
        var daController = (from type in allTypes
                            where type.IsSubclassOf(baseControllerType)
                            select type).FirstOrDefault();
        // optionally create an instance.
        var instance = Activator.CreateInstance(daController);
    }
    public class BaseObject
    {
    }
    public class TestObject : BaseObject
    {
    }
    public class BaseController<T>
    {
    }
    public class TestObjectController : BaseController<TestObject>
    {
    }
