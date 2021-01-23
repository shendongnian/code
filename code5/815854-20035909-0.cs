    class Form1 : Form
    {
        Queue<string> ButtonQueue = new Queue<string>();
        System.Windows.Forms.Timer theTimer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            buttonQueue = new Queue();
            theTimer.Tick += new EventHandler(theTimer_Tick);
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Name.Equals("Button"))
            {
                buttonQueue.Enqueue(((Button)sender).Text);
            }
        }
        void theTimer_Tick(object sender, EventArgs e)
        {
            theTimer.Enabled = false;
            
            switch (ButtonQueue.Dequeue().ToUpper())
            {
                case "UP":
                    //Run animation include Application.DoEvents() in the animation loop to prevent GUI lockup 
                    break;
                case "DOWN":
                    //Run animation include Application.DoEvents() in the animation loop to prevent GUI lockup 
                    break;
                case "OPEN":
                    //Run animation include Application.DoEvents() in the animation loop to prevent GUI lockup 
                    break;
            }
            theTimer.Enabled = true;
        }    }
