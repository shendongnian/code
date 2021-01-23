    using System.Linq;
    using Dapper;
    namespace DapperTestProj.DapperAttributeMapper
    {
        public class ColumnAttributeTypeMapper<T> : FallBackTypeMapper
        {
            public ColumnAttributeTypeMapper()
                : base(new SqlMapper.ITypeMap[]
                        {
                            new CustomPropertyTypeMap(typeof(T),
                                (type, columnName) =>
                                    type.GetProperties().FirstOrDefault(prop =>
                                        prop.GetCustomAttributes(false)
                                            .OfType<ColumnAttribute>()
                                            .Any(attribute => attribute.Name == columnName)
                                )
                            ),
                            new DefaultTypeMap(typeof(T)) 
                        })
            {
            }
        }
    }
