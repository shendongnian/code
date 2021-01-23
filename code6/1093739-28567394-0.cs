    namespace WpfApplication1
    {
    
        public enum StateEnum
        {
            Pass,
            Fail,
            Mandatory,
            Retest
        }
    
        public class ModuleRecord
        {
            public int Id { get; set; }
            public StateEnum Operation1 { get; set; }
            public StateEnum Operation2 { get; set; }
            public StateEnum Operation3 { get; set; }
            public StateEnum Operation4 { get; set; }
        }
    
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                ModuleRecords = new ObservableCollection<ModuleRecord>();
            }
    
            public ObservableCollection<ModuleRecord> ModuleRecords { get; set; }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                
                for (int i = 0; i < 5; i++)
                {
                    int j = 1;
                    var mRecord = new ModuleRecord();
                    mRecord.Id = j;
                    mRecord.Operation1 = StateEnum.Pass;
                    mRecord.Operation2 = StateEnum.Pass;
                    mRecord.Operation3 = StateEnum.Pass;
                    mRecord.Operation4 = StateEnum.Pass;
                    ModuleRecords.Add(mRecord);
                    
                }
                DataContext = this;
            }
        }
    }
