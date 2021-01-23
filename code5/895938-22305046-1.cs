    public partial class Form2 : Form
    {        
        public Form2()
        {
            InitializeComponent();
        }
        private void LoadTree(Object o, EventArgs e)
        {
            //do work
            MessageBox.Show("Loading tree...");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Form3();
            form.LoadTreeEvent += form_LoadTreeEvent;//Hook into the Form3 event 
            form.Show();
        }
        void form_LoadTreeEvent(object o, EventArgs e)
        {
            LoadTree(o, e);//Handle Form3 Event
        }
    }
    public partial class Form3 : Form
    {
        //The event is raised by Form3, however it's handled by Form2.
        public event LoadTreeHandler LoadTreeEvent;        
        public delegate void LoadTreeHandler(Object o, EventArgs e);
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadTreeEvent(null, null);//Raise the event in Form3 and pass whatever
            //do work...maybe close this form??
        }
    }
