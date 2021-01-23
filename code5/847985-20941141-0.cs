    public class EnumMapper<T> : NHibernate.Type.EnumStringType<T>
    {
       // Regular mapping code here
    
       public static IPropertyConvention Convention
       {
          get
          {
             return ConventionBuilder.Property.When(
                c => c.Expect(x => x.Type == typeof (GenericEnumMapper<T>)),
                x => x.CustomType<EnumMapper<T>>()
                );
          }
       }
    }
