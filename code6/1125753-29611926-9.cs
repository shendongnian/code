    public class Waiter : INotifyPropertyChanged
    {
        public async Task<String> Get1()
        {
            await Task.Delay(2000);            
            return "Got value 1";
        }
        
        public async Task<String> Get2()
        {
            await Task.Delay(3000);
            return "Got value 2";
        }
        private void FailFast(Task task)
        {
            MessageBox.Show(task.Exception.Message);
            Environment.FailFast("Unexpected failure");
        }
        public async Task InitialLoad()
        {          
            this.Value = "Loading started";
            var task1 = Get1();
            var task2 = Get2();
            // You can also add ContinueWith OnFaulted for task1 and task2 if you do not use the Result property or check for Exception
            var tasks = new Task[]
            {
                task1.ContinueWith(
                    (prev) => 
                        this.Value1 = prev.Result),
                task2.ContinueWith(
                    (prev) => 
                        this.Value2 = prev.Result)
            };
            
            await Task.WhenAll(tasks);
            this.Value = "Loaded";
        }
        public Waiter()
        {
            InitialLoad().ContinueWith(FailFast, TaskContinuationOptions.OnlyOnFaulted);
        }
        private String _Value,
            _Value1,
            _Value2;
        public String Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                if (value == this._Value)
                    return;
                this._Value = value;
                this.OnPropertyChanged();
            }
        }
        public String Value1
        {
            get { return this._Value1; }
            set
            {
                if (value == this._Value1)
                    return;
                this._Value1 = value;
                this.OnPropertyChanged();
            }
        }
        public String Value2
        {
            get { return this._Value2; }
            set
            {
                if (value == this._Value2)
                    return;
                this._Value2 = value;
                this.OnPropertyChanged();
            }
        }
        public void OnPropertyChanged([CallerMemberName]String propertyName = null)
        {
            var propChanged = this.PropertyChanged;
            if (propChanged == null)
                return;
            propChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Waiter();          
        }
    }
