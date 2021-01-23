    public class ExampleEntityMap : ClassMapping<ExampleEntity>
    {
        public ExampleEntityMap()
        {
            Table("Table");
            ComposedId(i => i.Property(p => p.MyIdColumn, map =>
                                                        {
                                                            map.Column("MyIdColumn");
                                                            map.Type<MyIdColumnUserType>();
                                                        }));
            Property(i => i.Country, map =>
                                  {
                                      map.Column("Country");
                                      map.Type<CountryEnumUserType>();
                                  });
        }
    }
