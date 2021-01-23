    static class ModelStateMappings
    {
        public static DomainModelMapping<TDomainModel> MapDomainModel<TDomainModel>()
        {
            // edit the constructor to pass more information here if needed.
            return new DomainModelMapping<TDomainModel>();
        }
    }
    public class DomainModelMapping<TDomainModel>
    {
        public ViewModelMapping<TDomainModel, TViewModel> MapViewModel<TViewModel>()
        {
            // edit the constructor to pass more information here if needed.
            return new ViewModelMapping<TDomainModel, TViewModel>();
        }
    }
    public class ViewModelMapping<TDomainModel, TViewModel>
    {
        public ViewModelMapping<TDomainModel, TViewModel>
            Properties<TDomainPropertyType, TViewModelPropertyType>(
                Expression<Func<TDomainModel, TDomainPropertyType>> domainExpr,
                Expression<Func<TViewModel, TViewModelPropertyType>> viewModelExpr)
        {
            // map here
            return this;
        }
    }
