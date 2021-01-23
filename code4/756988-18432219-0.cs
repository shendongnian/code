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
    public abstract class Extension {
      public string Name;
      public abstract List<View> Views;
    }
    public class Module : Extension {
        public List<ModuleView> Views;
    }
    public class Component : Extension {
        public List<ComponentView> Views;
    }
