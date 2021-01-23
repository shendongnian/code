    public class MainViewModel :
    {
      private IAnalyzerViewModel _analyzerViewModel;
      public IAnalyzerViewModel SelectedViewModel { get { return _analyzerViewModel; } set { _analyzerViewModel = value; OnPropertyChanged(() => SelectedViewModel); }
      
      //Hook up the selected item changed event of your listbox and set the appropriate ViewModel to show, so if you either want to show the AnalyzerGroup or AnalyzerView.
    }
