    public Main()
    {
        InitializeComponent();
        //Works for panels, richtextboxes, 3rd party etc..
        Application.AddMessageFilter(new ScrollableControls(panel1, richtextbox1, radScrollablePanel1.PanelContainer));
    }
