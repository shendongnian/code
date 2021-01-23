    public class ColumnOrForeignKeyAttributeTypeMapper<T> : FallBackTypeMapper
        {
            public ColumnOrForeignKeyAttributeTypeMapper()
                : base(new SqlMapper.ITypeMap[]
                        {
                            new CustomPropertyTypeMap(typeof(T),
                                (type, columnName) =>
                                    type.GetProperties().FirstOrDefault(prop =>
                                        prop.GetCustomAttributes(false)
                                            .Where(a=>a is ColumnAttribute || a is ForeignKeyAttribute)
                                            .Any(attribute => attribute.GetType() == typeof(ColumnAttribute) ? 
                                                ((ColumnAttribute)attribute).Name == columnName : ((ForeignKeyAttribute)attribute).Name == columnName)
                                )
                            ),
                            new DefaultTypeMap(typeof(T))
                        })
            {
            }
        }
