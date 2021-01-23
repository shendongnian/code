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
            
            //logic
        }
    }
