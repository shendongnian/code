    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += (s, e) =>
            {
                Func<Task> doAsync = async () =>
                {
                    await Task.Delay(2000);
                };
                var task = doAsync();
                var handle = ((IAsyncResult)task).AsyncWaitHandle;
                var startTick = Environment.TickCount;
                handle.WaitOne(4000);
                MessageBox.Show("Lapse: " + (Environment.TickCount - startTick));
            };
        }
    }
