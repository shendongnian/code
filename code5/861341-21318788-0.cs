    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click( object sender, EventArgs e )
            {
                var logChecker = new LogChecker();
                logChecker.FinishedExvent += () => MessageBox.Show( "Finished" );
                logChecker.Start();
            }
        }
    
        internal class LogChecker
        {
            public void Start()
            {
                var thread = new Thread( CheckLog );
                thread.Start();
            }
    
            private void CheckLog()
            {
                var progress = 0;
                while ( progress < 3000 )
                {
                    Thread.Sleep( 250 );
                    progress += 250;
                }
                FinishedExvent();
            }
    
            public event TestEventHandler FinishedExvent;
        }
    
        internal delegate void TestEventHandler();
    }
