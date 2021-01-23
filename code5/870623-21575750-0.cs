    public partial class MainWindow : Window
    {
        class Model
        {
            Model() { }
            public Task<int> AsyncTask { get; private set; }
            public static Model Create()
            {
                var model = new Model();
                Func<Task<int>> doTaskAsync = async () =>
                {
                    await Task.Delay(1);
                    return 42;
                };
                model.AsyncTask = doTaskAsync();
                return model;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var textBlock = new TextBlock();
            var window = new Window { Content = textBlock };
            window.Loaded += (sIgnore, eIgnore) =>
            {
                // int result = ((Model)window.DataContext).AsyncTask.Result;
                // textBlock.Text = result.ToString();
            };
            window.DataContext = Model.Create();
            window.ShowDialog();
            MessageBox.Show("Result: " + 
                ((Model)window.DataContext).AsyncTask.Result);
        }
    }
