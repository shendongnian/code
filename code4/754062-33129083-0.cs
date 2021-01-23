    public abstract class SomeClassMapBase<T> : ClassMap<SomeClass<T>>
    {
        public SomeClassMapBase()
        {
            Map(x => x.SomeIntProp);
            Map(x => x.SomeStringProp);
        }
    }
    public class SomeClassReferencedClassMap : SomeClassMapBase<ReferencedClass>
    {
        public SomeClassReferencedClassMap()
        {
            CompositeId()
                .KeyReference(x => x.Referenced, "Refernece_id");
        }
    }
