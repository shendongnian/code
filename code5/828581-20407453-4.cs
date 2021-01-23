    public class foo{
        private List<type> list = new List<type>;
        public type this[int i]{
            get{return list[i]}
            get{list[i] = value}
        }
    }
    //Much later....
    foo Foo = new foo();
    Console.WriteLine(Foo[1]);
