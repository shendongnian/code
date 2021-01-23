    public class ChildrenViewModel
    {
        public ChildrenViewModel()
        {}
        public ChildrenViewModel(IViewModelFactory<IChildViewModel> factory)
        {
            ChildViewModels = new ObservableCollection<IChildViewModel>(factory.Create());
        }
        public ObservableCollection<IChildViewModel> ChildViewModels { get; set; }
    }
