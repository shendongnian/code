    public partial class DynamicForm : Form
    {
        Processor p = new Processor();
        public DynamicForm()
        {
            InitializeComponent();
   
            // this doesn't create a new instance
            p.UpdateWindow(this);
        }
    }
