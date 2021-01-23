    public class AnalyzerGroupWorkspaceViewModel : PropertyChangedBase, IAnalyzerGroupWorkspaceViewModel
    {
        private IAnalyzerViewModel selectedViewModel;
        private const string WorkspaceName = "Analyzers";
        public AnalyzerGroupWorkspaceViewModel(
            IMappingEngine fromMapper,
            IRepository<Model.AnalyzerGroup> analyzerGroups)
        {
            AnalyzerGroups = new ObservableCollection<IAnalyzerGroupViewModel>(
                analyzerGroups.GetAll().Select(
                    fromMapper.Map<Model.AnalyzerGroup, AnalyzerGroupViewModel>));
        }
        public void SelectionChanged(object eventArgs)
        {
            var typedEventArgs = eventArgs as SelectionChangedEventArgs;
            if (typedEventArgs != null)
            {
                if (typedEventArgs.AddedItems.Count > 0)
                {
                    var item = typedEventArgs.AddedItems[0];
                    var itemAsGroup = item as IAnalyzerViewModel;
                    if (itemAsGroup != null)
                    {
                        SelectedViewModel = itemAsGroup;
                    }
                }
            }
        }
        public ObservableCollection<IAnalyzerGroupViewModel> AnalyzerGroups { get; private set; }
        public string Name { get { return WorkspaceName; } }
        public IAnalyzerViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                if (Equals(value, selectedViewModel))
                {
                    return;
                }
                if (SelectedViewModel != null)
                {
                    SelectedViewModel.IsSelected = false;
                }
                selectedViewModel = value;
                NotifyOfPropertyChange(() => SelectedViewModel);
            }
        }
    }
