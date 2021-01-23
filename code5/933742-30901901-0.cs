    public class RotatingSpecimenBuilder<T> : ISpecimenBuilder
    {
        protected const int Seed = 812039;
        protected readonly static Random Random = new Random(Seed);
        private static readonly List<Type> s_allTypes = new List<Type>();
        private readonly List<Type> m_derivedTypes = new List<Type>();
        private readonly Type m_baseType = null;
        static RotatingSpecimenBuilder()
        {
            s_allTypes.AddRange(AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()));
        }
        public RotatingSpecimenBuilder()
        {
            m_baseType = typeof(T);
            m_derivedTypes.AddRange(s_allTypes.Where(x => x != m_baseType && m_baseType.IsAssignableFrom(x)));
        }
        public object Create(object request, ISpecimenContext context)
        {
            var t = request as Type;
            if (t == null || t != m_baseType || m_derivedTypes.Count == 0)
            {
                return new NoSpecimen(request);
            }
            var derivedType = m_derivedTypes[Random.Next(0, m_derivedTypes.Count - 1)];
            return context.Resolve(derivedType);
        }
    }
