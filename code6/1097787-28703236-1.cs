    public class MapMyClass() : ClassMap<MyClass>
    {
        public MapMyClass{
           Table("MYTABLE");
           Id(c => c.ID);
           Map(c => c.NAME);
        }
    }
