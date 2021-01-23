    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            DetachedForm detachedForm = new DetachedForm();
            detachedForm.SelectionMade += new EventHandler<SelectionMadeEventArgs>(detachedForm_SelectionMade);            
            detachedForm.Show();
        }
        void detachedForm_SelectionMade(object sender, SelectionMadeEventArgs e)
        {
            OutputBox.Text = e.ActualSelection;
        }
    }
