    public class Thing
    {
       public int ID {get; set;}
       public virtual IEnumerable<Widget> Widgets {get; set;}
    }
    
    public class Widget
    {
       public int ID {get; set;}
       public virtual IEnumerable<Thing> Things {get; set;}
    }
