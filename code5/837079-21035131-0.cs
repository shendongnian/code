    public class BaseMapping<E> : ClassMap<E>
        where E: BaseEntity
    {
        public BaseMapping(string schema, string table)
        {
            Schema(schema);
            Table(table);
            Id(model => model.Id, "Id");
        }
    }
