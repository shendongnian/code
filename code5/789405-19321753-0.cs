    public partial class SplashScreenForm<T> : Form
    {
        private BackgroundWorker _backgroundWorker;
        private Func<BackgroundWorker, T> _func;
        private T _funcResult;
        public T FuncResult { get { return _funcResult; } }
        public SplashScreenForm(Func<BackgroundWorker, T> func)
        {
            this._func = func;
            InitializeComponent();
            this.label1.Text = "";
            this._backgroundWorker = new BackgroundWorker();
            this._backgroundWorker.WorkerReportsProgress = true;
            this._backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);
            this._backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(_backgroundWorker_ProgressChanged);
            this._backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker_RunWorkerCompleted);
            _backgroundWorker.RunWorkerAsync();
        }
        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            if (worker != null)
            {
                _funcResult = this._func.Invoke(worker);
            }
        }
        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                this.label1.Text = e.UserState.ToString();
            }
        }
        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
