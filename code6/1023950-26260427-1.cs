    public partial class incidentCategoryChange : UserControl
    {
        public static incidentCategoryChange Instance {get; private set;}
        public incidentCategoryChange()
        {
            InitializeComponent();
            Instance = this;
        }
        public string TextBoxCategory
        {
            get { return incidentCategoryTextBox.Text; }
            set { incidentCategoryTextBox.Text = value; }
        }
    }
