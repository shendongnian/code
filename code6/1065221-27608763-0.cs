    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }
        private CancellationTokenSource _tokenSource;
        private async void start_Click(object sender, EventArgs e)
        {
            if (_tokenSource != null)
                return;
            _tokenSource = new CancellationTokenSource();
            var ct = _tokenSource.Token;
            await Task.Factory.StartNew(() =>
            {
                for (; ; )
                {
                    if (ct.IsCancellationRequested)
                        break;
                    doSomething();
                }
            }, ct);
            _tokenSource = null;
        }
        private int _labelCounter;
        private void doSomething()
        {
            // do something
            Invoke((Action)(() =>
            {
                myLabel.Text = (++_labelCounter).ToString();
            }));
        }
        private void stop_Click(object sender, EventArgs e)
        {
            if (_tokenSource == null)
                return;
            _tokenSource.Cancel();
        }
    }
