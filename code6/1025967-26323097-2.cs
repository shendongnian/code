    public Form1()
    {
        InitializeComponent();
        Panel panelDummy = new Panel();
        panelDummy.Size = new Size(1,1);
        panelDummy.Location = new Point(yourMaxX,yourMaxY);
        panel1.Controls.Add(panelDummy);
    }
