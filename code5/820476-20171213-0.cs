       public Form1()
        {
            InitializeComponent();
            Thread setTextT = new Thread(TextSetter);
            setTextT.Start();
        }
    
        private void TextSetter()
        {
            //Thread.Sleep(4000);
            //textBox1.Text = "Hello World";
            //You have to Invoke your action to the UI thread
            Invoke(new Action(()=>textBox1.Text = "Hello World"));
        }
