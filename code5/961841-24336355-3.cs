    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> _specA;
        private ISpecification<T> _specB;
        public AndSpecification(ISpecification<T> specA, ISpecification<T> specB)
        {
            _specA = specA;
            _specB = specB;
        }
        public bool Satisfied(T entity)
        {
            return _specA.Satisfied(entity) && _specB.Satisfied(entity);
        }
    }
    public static class SpecificationExtensions
    {
        public static ISpecification<T> And<T>(
           this ISpecification<T> specA, ISpecification<T> specB)
        {
            return new AndSpecification<T>(specA, specB);
        }
    }
