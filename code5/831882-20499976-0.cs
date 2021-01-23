    public Form1()
        {
            InitializeComponent();
            comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", radioButton1, "Checked", true, DataSourceUpdateMode.OnPropertyChanged));
        }
