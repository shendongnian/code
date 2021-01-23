        public class GenerationDepthBehavior: ISpecimenBuilderTransformation
        {
            public int Depth { get; }
            public GenerationDepthBehavior(int depth)
            {
                Depth = depth;
            }
    
            public ISpecimenBuilderNode Transform(ISpecimenBuilder builder)
            {
                return new RecursionGuard(builder, new OmitOnRecursionHandler(), new IsSeededRequestComparer(), Depth);
            }
            private class IsSeededRequestComparer : IEqualityComparer
            {
                bool IEqualityComparer.Equals(object x, object y)
                {
                    return x is SeededRequest && y is SeededRequest;
                }
                int IEqualityComparer.GetHashCode(object obj)
                {
                    return obj is SeededRequest ? 0 : EqualityComparer<object>.Default.GetHashCode(obj);
                }
            }
        }
https://github.com/AutoFixture/AutoFixture/issues/1032#issuecomment-385928866
