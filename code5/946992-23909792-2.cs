    ListView dummy;
    public Form1()
    {
        InitializeComponent();
        dummyLV = new ListView();
        dummyLV.Visible = false;
        dummyLV.Enabled = false;
        this.Controls.Add(dummyLV );
        //..
