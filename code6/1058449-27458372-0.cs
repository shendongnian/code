    public partial class Form1 : Form
    {
        private readonly ListBox _listBox;
        public Form1()
        {
            InitializeComponent();
            _listBox = new ListBox();
            var backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true ,
                WorkerSupportsCancellation = true
            };
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync( new List<object>() );
        }
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var result = new List<object>();
            var backgroundWorker = ( BackgroundWorker ) sender;
            var enumerable = ( IEnumerable<object> ) e.Argument;
            foreach ( var item in enumerable )
            {
                if ( backgroundWorker.CancellationPending )
                {
                    e.Cancel = true;
                    return;
                }
                // Logic to get file thumbnail
                result.Add( item );
                backgroundWorker.ReportProgress( 0 , item );
            }
            e.Result = result;
        }
        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _listBox.Items.Add( e.UserState );
        }
        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ( e.Cancelled ) return;
            if ( e.Error != null )
            {
                // Handle exception
                return;
            }
            var listOfThumbnails = e.Result;
        }
    }
