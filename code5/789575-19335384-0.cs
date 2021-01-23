    internal class DbSetTypeSpecification : IRequestSpecification
    {
        public bool IsSatisfiedBy(object request)
        {
            var type = request as Type;
            if (type == null)
                return false;
            return type.IsGenericType
                && typeof(DbSet<>) == type.GetGenericTypeDefinition();
        }
    }
