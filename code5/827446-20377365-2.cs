    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
    
        public bool ChildIsOpen {get; set;}
        private void showChildForms(object sender, EventArgs e)
        {
            createThread();
            createThread();
            createThread();
        }
    
        private  void createThread()
        {
            if(ChildIsOpen)
                 return;
            var t = new Thread(
                   () =>
                   {
                       this.Invoke(new Action(delegate
                       {
    
                           showForm();
                       }));
                   }
                   );
            t.IsBackground = true;
            t.Start();
        }
    
        private void showForm()
        {
            using (ChildForm childForm = new ChildForm())
            {
                childForm .Load += (o, args) => ChildIsOpen = true;
                childForm .Closed += (o, args) => ChildIsOpen = false;
                childForm .ShowDialog();
            }
        }
    }
