    public abstract Class CodeTableBase
    {
        public virtual int Id { get; protected set; }
        public virtual string CodeType { get; protected set; }
        public virtual int Value { get; protected set; }
        public virtual string Description { get; protected set; }
    }
    public class City : CodeTableBase {}
    public abstract class CodeTableMap<T> : ClassMap<T> where T : CodeTableBase
    {
        public CodeTableMap() 
        {
            Table("CodeTable");
            Id(x => Id, "id").your id generation strategy
            CodeType(x => x.CodeType, "code_type");
            Value(x => x.Value, "code_value");
            Description(x => x.Description, "code_description");
        }
        
        public CodeTableMap(string codeType) : this()
        {
            Where("code_type = '" + codeType + '"); // may need to use property name
        }
    }
    public class CityMap : CodeTableMap<City>
    {
        public CityMap : base("city") {}
    }
