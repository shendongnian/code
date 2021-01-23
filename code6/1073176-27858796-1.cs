    public interface IFoo
    {
        Model Model {get;set;}
    }
    public class Foo : IFoo 
    {
        public string Id{get;set;}
        public Model Model{get;set}
    }
    public static int GetId(this IFoo obj)
    {
        return obj.Model.Id;
    }
