    public partial class Form1 : Form
    {
        AutoResetEvent are = new AutoResetEvent(true);
        public Form1()
        {
            InitializeComponent();
            _updateGUI = new UpdateGUIDelegate(UpdateGUI);
            
            Task.Factory.StartNew(() => BuildTest());
        }
        private void BuildTest()
        {
            for (int test = 0; test < 5; test++)
                for (int variation = 0; variation < 4; variation++)
                    for (int subtest = 0; subtest < 3; subtest++)
                    {
                        are.WaitOne();
                        if (this.InvokeRequired)
                            this.Invoke(_updateGUI, test, variation, subtest);
                        else
                            UpdateGUI(test, variation, subtest);
                                             
                    }
        }
        delegate void UpdateGUIDelegate(int test, int variation, int subtest);
        private UpdateGUIDelegate _updateGUI;
        private void UpdateGUI(int test, int variation, int subtest)
        { }
        private void btn_Click(object sender, EventArgs e)
        {
            are.Set();   
        }
    }
