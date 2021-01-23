    public class foo{
        private List<type> list = new List<type>;
        public IList<type> List{
            get{return list.AsReadOnly()}
        }
    }
    //Much later....
    foo Foo = new foo();
    Foo.List.Clear();   // not possible
