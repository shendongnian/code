    public abstract class View
    {
        // ...
    }
    public class ModuleView : View
    { 
    }
    public class ComponentView : View
    {
        public object Foo; //Substitute object with whatever type Foo is
    }
    public abstract class Extension
    {
      public string Name;
      public abstract List<View> Views { get; set; }
    }
    public class Module : Extension 
    {
        public override List<View> Views 
        {
            get
            {
                ModuleView moduleViewA = new ModuleView();
                ModuleView moduleViewB = new ModuleView();
                //Continue building whatever ModuleView objects you need...
                return new List<View>()
                {
                    moduleViewA,
                    moduleViewB,
                    //...plus all other ModuleView objects you built
                };
            }
            set 
            {
                Views = value;
            }
        }
    }
    public class Component : Extension 
    {
        public override List<View> Views
        {
            get
            {
                ComponentView compViewA = new ComponentView();
                ComponentView compViewB = new ComponentView();
                //Continue building whatever ComponentView objects you need...
                return new List<View>()
                {
                    compViewA,
                    compViewB,
                    //...plus all other ComponentView objects you built
                };
            }
            set
            {
                Views = value;
            }
        }
    }
