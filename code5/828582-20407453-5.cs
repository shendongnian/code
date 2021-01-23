    public class foo{
        private List<type> list = new List<type>;
        public List<type> List{
            get{return list}
        }
    }
    //Much later....
    foo Foo = new foo();
    Foo.List.Clear();   // perfectly legal
