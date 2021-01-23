    public class Foo{
    
    public ObservableCollection<MyParentObject> ListToBind {get;set;}
     
    .... (rest of properties)
    }
    
    public class MyParentObject{
    
    public ObservableCollection<MyChildObject> ChildListToBind {get;set;}
    .... (rest of properties)
    }
