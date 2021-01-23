    public class Address 
    {
       public int Id1 { get; set; }
       public int Id2 { get; set; }
       public virtual Person Person { get; set; }
    }
    public void Foo() 
    {
       IEnumerable<MyObj> = context.Address.Select(x => new {
                                                               Id1 = x.Id1,
                                                               Id2 = x.Id2,
                                                               PersonId = x.Person.Id 
                                                             });
    }
