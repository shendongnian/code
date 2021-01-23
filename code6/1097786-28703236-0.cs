    public class MapMyClass() : ClassMap<MyClass>
    {
        public MapMyClass{
           Table("MYCLASS");
           Id(c => c.ID);
           Map(c => c.NAME);
        }
    }
