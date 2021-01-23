    public partial class DynamicForm : Form
    {
        Processor p = new Processor();
        public DynamicForm()
        {
            InitializeComponent();
            UpdateWindow();
        }
        
        private void UpdateWindow()
        {
            this.Text = "Title";
            UpdateListView(); 
            UpdatePanelPage();
            UpdatePanelSelection();
        }
    }
