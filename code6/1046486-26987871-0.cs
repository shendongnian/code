    namespace EventSample
    {
        public delegate void AfterChildEventHandler(Control control,Keys key);
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                aControl1.OnChildFireEvent += OnChildFireEvent;
                bControl1.OnChildFireEvent += OnChildFireEvent;
            }
    
            void OnChildFireEvent(Control control, Keys key)
            {
                MessageBox.Show("Form fired event from " + control.GetType().Name);
            }
        }
    }
