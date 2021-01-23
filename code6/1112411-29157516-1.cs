    public class Foo
    {
       public int Id{get;set}
       //...
    }
    public class Boo
    {
       [Key,ForeignKey("Foo")]
       public int FooId{get;set}
       public virtual Foo Foo{get;set;}
       //...
    }
