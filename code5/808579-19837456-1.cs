    public class ExtendedLinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public ExtendedLinqToHqlGeneratorsRegistry()
        {
            this.Merge(new DateTimeDayOfYearPropertyHqlGenerator());
        }
    }
