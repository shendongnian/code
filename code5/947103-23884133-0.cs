    public partial class Window1 : Window
    {
        TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
        public Window1()
        {
            InitializeComponent();
            this.Closed += Window1_Closed;
        }
        void Window1_Closed(object sender, EventArgs e)
        {
            tcs.SetResult(null);
        }
        public async Task ShowAsync()
        {
            Show();
            await tcs.Task;
        }
    }
