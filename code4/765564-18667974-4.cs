    public delegate void ObjectADoSomethingEventHandler(object sender, ObjectADoSomethingEventArgs e);
    public class ObjectADoSomethingEventArgs : EventArgs
    {
        public int Value { get; private set; }
        public ObjectADoSomethingEventArgs(int value)
        {
            Value = value;
        }
    }
    public class ObjectA
    {
        public event ObjectADoSomethingEventHandler DoSomething;
        protected void OnDoSomething(int value)
        {
            if (DoSomething != null)
                DoSomething(this, new ObjectADoSomethingEventArgs(value));
        }
        public event EventHandler Closed;
        protected void OnClosed()
        {
            if (Closed != null)
                Closed(this, new EventArgs());
        }
        private BackgroundWorker _worker;
        public ObjectA()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += new DoWorkEventHandler(_objectA_DoWork);
            _worker.ProgressChanged += new ProgressChangedEventHandler(_objectA_ProgressChanged);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_objectA_RunWorkerCompleted);
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
        }
        public void Start()
        {
            _worker.RunWorkerAsync();
        }
        public void Kill()
        {
            if (_worker != null && _worker.IsBusy)
            {
                _worker.CancelAsync();
            }
        }
        private void _objectA_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 0;
            while (true)
            {
                _worker.ReportProgress(count);
                count++;
                if (count > 20)
                {
                    return; // exit thread.
                }
                if (_worker.CancellationPending)
                {
                    e.Cancel = true;
                    return; // Thread cancelled.
                }
                Thread.Sleep(500);
            }
        }
        private void _objectA_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnDoSomething(e.ProgressPercentage);
        }
        private void _objectA_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnClosed();
        }
    }
    public partial class Form1 : Form
    {
        private ObjectA _objectA;
        public Form1()
        {
            InitializeComponent();
            _objectA = new ObjectA();
            _objectA.DoSomething += _objectA_DoSomething;
            _objectA.Closed += _objectA_Closed;
            _objectA.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _objectA.Kill();
        }
        private int _red = 128;
        private int _green = 128;
        private int _blue = 128;
        void _objectA_DoSomething(object sender, ObjectADoSomethingEventArgs e)
        {
            _red += 15;
            if (_red > 255) _red = 128;
            _green -= 15;
            if (_green < 0) _green = 128;
            _blue += 15;
            if (_blue > 255) _blue = 128;
            this.BackColor = Color.FromArgb(_red, _green, _blue);
            this.Text = string.Format("Count = {0}", e.Value);
        }
        void _objectA_Closed(object sender, EventArgs e)
        {
            Close();
        }
    }
