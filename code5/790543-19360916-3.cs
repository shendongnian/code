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
            
            var result = source.Foos.Select(foo => MapBar(foo, source.Id));
            return result;
        }
        private static Bar MapBar(Foo item, Guid id)
        {
            // Use the existing Foo => Bar mapping
            var bar = Mapper.Map<Foo,Bar>(item);
            bar.Id = id;
            return bar;
        }
    }
