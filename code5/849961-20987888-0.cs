    class Foo
    {
    public static List<Foo> Instances = new List<Foo>();
    public Foo
    {
    Instances.Add(this);
    }
    //can be accessed like below
    Foo.Instances
