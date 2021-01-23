    public abstract class ClassMapBase<T> : ClassMap<T> where T: EntityBase
    {
        protected ClassMapBase()
        {
            Id(x => x.Id).Not.Nullable().GeneratedBy.GuidComb();
            LazyLoad();
        }
    }
