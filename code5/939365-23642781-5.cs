    public partial class SampleWindow : Window
    {
      SampleModel _model = new SampleModel();
      public SampleWindow() {
        InitializeComponent();
        DataContext = _model; // attach the model/viewmodel to DataContext for binding in XAML
      }
    }
