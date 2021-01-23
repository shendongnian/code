    public class SkipMapIfNullResolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            if (source.Value == null)
                source.ShouldIgnore = true;
            return source;
        }
    }
