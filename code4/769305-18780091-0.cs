    public delegate void OnReceiveData( object sender, StreamWatcherEventArgs e );
    public class StreamWatcher
    {
        public event OnReceiveData DataReceived = delegate { };
        private Stream _stream;
        public StreamWatcher( Stream stream )
        {
            _stream = stream;
            CreateWatcherThread();
        }
        private void CreateWatcherThread()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += ( sender, args ) =>
            {
                while ( true )
                {
                    if ( _stream.Length > 0 )
                    {
                        byte[] buf = new byte[ _stream.Length ];
                        _stream.Seek( 0, SeekOrigin.Begin );
                        _stream.Read( buf, 0, buf.Length );
                        string data = ASCIIEncoding.ASCII.GetString( buf );
                        DataReceived( this, new StreamWatcherEventArgs( data ) );
                        _stream.SetLength( 0 );
                    }
                }
            };
            bw.RunWorkerAsync(); ;
        }
    }
