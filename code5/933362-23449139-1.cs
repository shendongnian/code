    public partial class frm1 : Form
    {
        private WebMethods wm;
        public frm1()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            wm = new WebMethods();
            wm.PostRequestCompletedEvent += wm_PostRequestCompletedEvent;
            wm.test();
        }
        void wm_PostRequestCompletedEvent(object sender, EventArgs e)
        {
            // notify frm1 that thread was finished 
        }
    }
    public partial class frm2 : Form
    {
        private WebMethods wm;
        public frm2()
        {
           InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
           wm = new WebMethods();
           wm.PostRequestCompletedEvent += wm_PostRequestCompletedEvent;
           wm.test();
        }
        void wm_PostRequestCompletedEvent(object sender, EventArgs e)
        {
            // notify frm2 that thread was finished
        }
    }
