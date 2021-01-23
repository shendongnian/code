    public class Extension {
          Public string Name {get; set;}
          Public List<View> Views {get; set;}
    }
    
    public class Component : Extension {
        // View.Foo is accessible here;
    }
    
    public class View {
        internal object Foo {get; set;}
    }
