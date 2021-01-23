    public partial class Window_Control : Window
    {
            RunningTime _runtime = new RunningTime();
            public Window_Control()
            {
                InitializeComponent();
                base.DataContext = _runtime;
            }
    }
