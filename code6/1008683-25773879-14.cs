    public class FillPropertiesView : IView<FillPropertiesModel>
    {
        public FillPropertiesView(FillPropertiesViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }
        
        public IViewModel<FillPropertiesModel> ViewModel { get; private set; }
    }
