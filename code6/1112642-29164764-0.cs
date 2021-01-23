    public class MyAbstractViewModel
    {
        public int Id{set;get;}
        public string Name{set;get;}
    
      public void MakeChildObject(MyAbstractViewModel vm, MyAbstractObject child)
      {
        child.Id = vm.Id;
        child.Name = vm.Name;
      }
    }
    public class MyChildViewModel: MyAbstractViewModel
    {
      public string Details {set;get;} 
      public MyChildObject MakeChildObject(MyChildViewModel vm)
      {
        var child = new  MyChildObject();
        this.MakeChildObject(this, child);
        child.Details= vm.Details;
    
        return child;
      }
    }
