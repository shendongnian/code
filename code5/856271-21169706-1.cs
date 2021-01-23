    public class ClassA_Map : ClassMap<A>
    {
        public ClassA_Map()
        {
            Table("tableA");
            ID(...)
            Property(...) 
    public class ClassB_Map : SubclassMap<B>
    {
        public ClassB_Map()
        {
            Table("tableB");
