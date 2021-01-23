        public class LinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
        {
            public LinqToHqlGeneratorsRegistry() : base()
            {
                RegisterGenerator(
                    ReflectionHelper.GetMethodDefinition(() => LinqExtensions.IsLikeWithEscapeChar(null, null, null)),
                    new CustomLikeGenerator());
            }
        }
