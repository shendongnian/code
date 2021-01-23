    void Main()
    {
        var a = new ObjectA
        {
            propertyX = Guid.NewGuid().ToString(),
            propertyY = Guid.NewGuid().ToString()
        };
        var b = new ObjectB(a);
        b.Dump();
    }
    public interface IObj
    {
        string propertyX{get;set;}
        string propertyY{get;set;}
    }
    public class ObjectA : IObj
    {
        public string propertyX{get;set;}
        public string propertyY{get;set;}
    }
    public class ObjectB: IObj
    {
        public string propertyX{get;set;}
        public string propertyY{get;set;}
        public ObjectB(ObjectA a)
        {
            var properties = typeof(IObj).GetProperties();
            var objAProperties = typeof(ObjectA).GetProperties();
            var objBProperties = typeof(ObjectB).GetProperties();
            var common = from p in properties
                         from propA in objAProperties
                         from propB in objBProperties
                         where p.Name == propA.Name && p.Name == propB.Name
                         select Tuple.Create(propA, propB);
            foreach(var tuple in common)
            {
                var value = tuple.Item1.GetValue(a);
                tuple.Item2.SetValue(this, value);
            }
        }
    }
