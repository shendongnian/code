    public class UniqueFieldValidator<TObject, TViewModel, TProperty> : PropertyValidator where TObject : Entity where TViewModel : Entity
    {
        private readonly IDataService<TObject> _dataService;
        private readonly Func<TObject, TProperty> _property;
        public UniqueFieldValidator(IDataService<TObject> dataService, Func<TObject, TProperty> property)
            : base("La propiedad {PropertyName} tiene que ser unica.")
        {
            _dataService = dataService;
            _property = property;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var model = context.Instance as TViewModel;
            var value = (TProperty)context.PropertyValue;
            if (model != null && _dataService.Where(t => t.Id != model.Id && Equals(_property(t), value)).Any())
            {
                return false;
            }
            return true;
        }
    }
    public class ArticuloViewModelValidator : AbstractValidator<ArticuloViewModel>
    {
        public ArticuloViewModelValidator(IDataService<Articulo> articuloDataService)
        {
            RuleFor(a => a.Codigo).SetValidator(new UniqueFieldValidator<Articulo, ArticuloViewModel, int>(articuloDataService, a => a.Codigo));
        }
    }
