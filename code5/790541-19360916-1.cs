    public class FooContainerTypeConverter
        : ITypeConverter<FooContainer, IEnumerable<Bar>>
    {
        public IEnumerable<Bar> Convert(ResolutionContext context)
        {
            var source = context.SourceValue as FooContainer;
            
            if(source == null)
            {
                return Enumerable.Empty<Bar>();
            }
            
            return source.Foos
                         .Select(f => new Bar { Name = f.Name, Id = source.Id });
        }
    }
