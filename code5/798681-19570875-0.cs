    public Label Label;
    public Form1()
    {
        Data version = new Data(); // this creates and instantiates a new Data object named Version
        InitializeComponent();
        CmboBoxLabel.Items.Add(new Label(version.LabelName, version.LabelCode));
    }
