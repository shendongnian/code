    public Airplane_Simulation()
           {
            InitializeComponent();
            CheckedChanged();
            rbZero.CheckedChanged += (s,e) => { CheckedChanged(); }
            rbOne.CheckedChanged += (s,e) => { CheckedChanged(); }
    public void CheckedChanged()
    {
        section =  rbZero.Checked ? rbZero.Text : rbOne.Text;
    }
