    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click( object sender, EventArgs e )
            {
                var logChecker = new Test();
                logChecker.ChangedEvent += x => MessageBox.Show( "Value is " + x );
                logChecker.Start();
            }
        }
    
        internal class Test
        {
            private bool _property;
    
            public Boolean Property
            {
                get { return _property; }
                set
                {
                    _property = value;
                    ChangedEvent( value );
                }
            }
    
            public void Start()
            {
                var thread = new Thread( CheckLog );
                thread.Start();
            }
    
            private void CheckLog()
            {
                var progress = 0;
                while ( progress < 2000 )
                {
                    Thread.Sleep( 250 );
                    progress += 250;
                }
                Property = true;
            }
    
            public event TestEventHandler ChangedEvent;
        }
    
        internal delegate void TestEventHandler( bool value );
