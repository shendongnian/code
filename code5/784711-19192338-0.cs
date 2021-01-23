     public partial class Form1 : Form
        {
            private bool _waiting;
            private bool _keyPressed;
            private const int TypingDelay = 220; // ms used for delay between keystrokes to initiate search
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void WaitWhileUserTyping()
            {
                var keepWaiting = true;
    
                while (keepWaiting)
                {
                    _keyPressed = false;
    
                    Thread.Sleep(TypingDelay);
    
                    keepWaiting = _keyPressed;
                }
    
                Invoke((MethodInvoker)(ExecuteSearch));
    
                _waiting = false;
            }
    
            private void ExecuteSearch()
            {
                Thread.Sleep(200); // do lookup
                
                // show search results...
                MessageBox.Show("Search complete");
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
    
                if (_waiting)
                {
                    _keyPressed = true;
                    return;
                }
    
                _waiting = true;
                // kick off a thread to do the search if nothing happens after x ms
                ThreadPool.QueueUserWorkItem(_ => WaitWhileUserTyping());
            }
        }
