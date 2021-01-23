    public partial class Form1 : Form
    {
        StreamWriter _writer;
        MemoryStream _ms = new MemoryStream();
        StreamWatcher _watcher;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load( object sender, EventArgs e )
        {
            _writer = new StreamWriter( _ms );
            _writer.AutoFlush = true;
            _watcher = new StreamWatcher( _ms );
            _watcher.DataReceived += _watcher_ReceivedData;
        }
        void _watcher_ReceivedData( object sender, StreamWatcherEventArgs e )
        {
            textBox2.Invoke( new Action( () => { textBox2.AppendText( "Data: " + e.Data ); } ) );
        }
        private void button1_Click( object sender, EventArgs e )
        {
            _writer.Write( textBox1.Text );
        }
    }
