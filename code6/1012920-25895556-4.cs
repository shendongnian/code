    public class StringToSafirStringResolver : ValueResolver<string, string>
    {
        protected override string ResolveCore(string source)
        {
            return source ?? "_";
        }
    }
    public class SafirStringToStringResolver : ValueResolver<string, string>
    {
        protected override string ResolveCore(string source)
        {
            return source == "_" ? null : source;
        }
    }
