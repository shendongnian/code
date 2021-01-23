        public MainForm()
        {
            InitializeComponent();
    //=====>Be careful change initial order between InitializeComponent
            CharStats form = new CharStats();
            form.Show();
        }
        public void SetInfo()
        {
            Variable2 = VariableLabel1;
            pcNameLabel.Text = Variable2;   
        }
    }
