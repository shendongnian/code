    public class DataSourceMap : DataSourceMapping<DataSource>
    {
        public DataSourceMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.InternalRefNr);
            ManyToOne(x => x.MyData);
        }
    }
