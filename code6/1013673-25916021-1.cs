    private class Parent
    {
        public int ID { get; set; }
    }
    private class Child : Parent
    {
            
    }
    private class MyList : List<Parent>
    {
        public new void Add(Parent item)
        {
            //runtime type check in case a Parent-derived object reaches here
            if (item.GetType() == typeof(Parent))
                base.Add(item);
            else
                throw new ArgumentException("List only supports Parent types");
        }
        [Obsolete("You can't add Child types to this list", true)]
        public void Add(Child item)
        {
            throw new NotImplementedException();
        }
    }
    static void Main(string[] args)
    {
        var list = new MyList();
        list.Add(new Parent() { ID = 1 });
        list.Add(new Child() { ID = 2 }); //This gives a compiler error
    }
