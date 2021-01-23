    public Form1()
    {
        InitializeComponent();
        comboxBox1.SelectedIndex = Properties.Settings.Default.SelectedIndex;
        this.Closing += Form1_Closing;
    }
    void Form1_Closing(object sender, CancelEventArgs e)
    {
        Properties.Settings.Default.SelectedIndex = comboxBox1.SelectedIndex;
        Properties.Settings.Default.Save();
    }
