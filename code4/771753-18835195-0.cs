    public class Model
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Categories Category { get; set; }
        public Grid PresenterContent { get; set; }
    }
    public class ViewModel : ViewModelBase
    {
        private ObservableCollection<Model> _model;
        public ObservableCollection<Model> Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (_model != value)
                {
                    _model = value;
                    RaisePropertyChanged(() => Model);
                }
            }
        }
        public ViewModel()
        {
            Model = new ObservableCollection<Model>();
        }
    }
    public partial class UserControl1 : public UserControl
    {
        UserControl1( )
        {
            this.DataContext = new ViewModel( );
        }
    }
    <DataGrid ItemsSource="{Binding Model}" />
