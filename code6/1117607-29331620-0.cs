    class Program
    {
        static void Main(string[] args)
        {
            SpecificManager specificManager = new SpecificManager();
            SpecificManager2 specificManager2 = new SpecificManager2();
            //...
            specificManager.Manage();
            specificManager2.Manage();
        }
    }
    public class Manager
    {
        dynamic myObject = null;
        public void ManagerInit (dynamic myObject)
        {
            this.myObject = myObject;
        }
        public void Manage()
        {
            if (myObject == null)
                return;
            // deal with BaseClass properties of the SpecificObject
            myObject.isAlive = true;
        }
    }
    public class SpecificManager : Manager
    {
        public SpecificObject myObjectSpec = new SpecificObject("Alfred");
        public SpecificManager ()
        {
            base.ManagerInit(myObjectSpec);
        }
        public void SpecificManage()
        {
            // Manage Attributes of SpecificObject class
            myObjectSpec.level = 2;
            base.Manage();
        }
    }
    public class SpecificManager2 : Manager
    {
        public SpecificObject2 myObjectSpec2 = new SpecificObject2("Alfred2");
        public SpecificManager2 ()
        {
            base.ManagerInit(myObjectSpec2);
        }
        public void SpecificManage2()
        {
            // Manage Attributes of SpecificObject2 class
            myObjectSpec2.description = "Foo";
            base.Manage();
        }
    }
    public class BaseClass
    {
        public string gameObject;
        public bool isAlive;
        public BaseClass(string gameObjectStructure)
        {
            this.gameObject = gameObjectStructure;
        }
    }
    public class SpecificObject : BaseClass
    {
        public int level = 0;
        public SpecificObject(string objectname) : base(objectname)
        {
        }
    }
    public class SpecificObject2 : BaseClass
    {
        public string description = String.Empty;
        public SpecificObject2(string objectname) : base(objectname)
        {
            
        }
    }
