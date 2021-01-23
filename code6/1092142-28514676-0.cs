    public class QueryValidationHandler : IQueryValidationHandler<IQuery>
    {
        private IEnumerable<IValidator<IQuery>> _validators;
        public QueryValidationHandler(IEnumerable<IValidator<IQuery>> validators) {
            _validators = validators;
        }
    }
