    abstract class ParentForm{
        ...
        public abstract void Update<T>(T updateValue)
    }
    
    public class f1 : ParentForm{
        ...
        private List<string> list;
        public override void Update(string value){
        list.Add(value);
    }
    }
    
    public class f2 : ParentForm{
        ....
        private List<int> list;
    public override void Update(int val){
     ...
    }
    }
