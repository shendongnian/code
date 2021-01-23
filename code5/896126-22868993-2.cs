    public partial class someForm : Form
        {
            public someForm()
            {
                InitializeComponent();
            }
        }
    partial class someForm
        {
            private void InitializeComponent()
                {
                    this.mainStatusBar = new StatusBar();
                }
        }
