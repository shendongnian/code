    public class Foo 
    {
        public string Name{get;set;} 
        //...
    }
---
    public static Expression<Func<Foo, bool>> NameEquals(string name)
    {
        return foo => foo.Name == name;
    }
