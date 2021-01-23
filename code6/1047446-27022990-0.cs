    using System.Reflection;
    public class Group<T> where T : Group<T>
    {
        public readonly object Key;
        public readonly IEnumerable<T> Groups;
        public readonly IEnumerable<DataRow> Drs;
        public Group(object key, IEnumerable<DataRow> source, List<string> columnList)
        {
            Key=key;
            if(columnList.Count==0)
                Drs=source;
            else
            {
                string firstColumn=columnList.First();
                List<string> restOfColumns=columnList.Skip(1).ToList();
                Groups=source.GroupBy(dr => dr[firstColumn])
                               .Select(g => Factory(g.Key, g, restOfColumns));
            }
        }
        static ConstructorInfo ctor;    //store constructor for type T
        static T Factory(object key, IEnumerable<DataRow> source, List<string> columnList)
        {
            if(ctor==null)
            {
                // if constructor not found yet, assign it
                ctor=typeof(T).GetConstructor(new Type[] {
                typeof(object),
                typeof(IEnumerable<DataRow>),
                typeof(List<string>)});
                if(ctor==null)
                {
                    throw new MissingMethodException("Could not find appropriate constructor");
                }
            }
            // invoke constructor to create a new T
            return ctor.Invoke(new object[] { key, source, columnList }) as T;
        }
    }
    public class SpecialGroup : Group<SpecialGroup>
    {
        public SpecialGroup(object key, IEnumerable<DataRow> source, List<string> columnList)
            : base(key, source, columnList) { }
        void DoSomething() { }
    }
