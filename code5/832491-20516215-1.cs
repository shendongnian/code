    public F2(F1 f1Ref)
    { 
        InitializeComponent();
        comboBox1.Items.Add(f1Ref.GetDGVHeaderText(0));
        comboBox2.Items.Add(f1Ref.GetDGVHeaderText(1));
    }
