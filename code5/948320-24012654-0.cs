    public class MsSqlGeometryConversion : IPropertyConvention
        {
            public void Apply(IPropertyInstance instance)
            {
                if (instance.Property.PropertyType.Equals(typeof(IGeometry)))
                {
                    instance.CustomType(typeof(MsSqlGeometryHandler));
                }
            }
        }
    
        public class MsSqlGeometryHandler : GeometryTypeBase<string>
        {
            public MsSqlGeometryHandler()
                : base(NHibernateUtil.String)
            {
            }
    
            protected override string FromGeometry(object value)
            {
                return value != null ? ((IGeometry)value).AsText() : null;
            }
    
            protected override IGeometry ToGeometry(object value)
            {
                return value != null ? new WKTReader().Read((string)value) : null;
            }
        }
