    public class KebabCaseNamingStrategy : SnakeCaseNamingStrategy
    {
        protected override string ResolvePropertyName(string name)
        {
            return base.ResolvePropertyName(name).Replace('_', '-');
        }
    }
