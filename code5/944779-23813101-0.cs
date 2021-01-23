    public Form1()
        {
            InitializeComponent();
            this.Load +=new EventHandler(Form1_Load);
        }
        public int MyFlowPanelOriginalSize { get; set; }
        public int MyFlowPanelNewSize { get; set; }
        public int DifferenceInSizeOfPanel { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            MyFlowPanelOriginalSize = MyFlowPanel.Width;
            MyFlowPanel.Resize += new EventHandler(MyFlowPanel_Resize);
            DifferenceInSizeOfPanel = 0;
        }
    
        void MyFlowPanel_Resize(object sender, EventArgs e)
        {
            MyFlowPanelNewSize = MyFlowPanel.Width;
            DifferenceInSizeOfPanel = MyFlowPanelNewSize - MyFlowPanelOriginalSize;
            var TextBoxDifference = MyTextBox.Width + DifferenceInSizeOfPanel;
            MyTextBox.Width = TextBoxDifference;
            MyFlowPanelOriginalSize = MyFlowPanel.Width;
        }
