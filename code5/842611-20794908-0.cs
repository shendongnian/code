     public TestWindow()
            {
                this.InitializeComponent();
    
                TestEvent += new TestDelegate(TestMethod);
    
                this.TestEvent(this, new EventArgs());
            }
