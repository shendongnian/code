    public class QueryValidationHandler : IQueryValidationHandler<IQuery>
    {
        private IValidator<IQuery> _validator;
        public QueryValidationHandler(IValidator<IQuery> validator) {
            _validator = validator;
        }
    }
