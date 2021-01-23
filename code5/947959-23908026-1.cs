    public class MainWindowViewModel {
  
        private readonly AppModel _model;
        public MainWindowViewModel(AppModel model) {
            _model = model;
        }
        public string OrgName {
            get { return _model.OrgName; }
        }
    }
