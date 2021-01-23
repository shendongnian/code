    public partial class Form_Parent : Form {
        public static Form_Parent Instance { get; private set; }
        public Form_Parent() {
            InitializeComponent();
            Instance = this;
        }
        // etc..
    }
