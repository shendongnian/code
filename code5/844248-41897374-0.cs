    public MainPage()
    {
        InitializeComponent();
        inkP.MouseMove += new MouseEventHandler(inkP_MouseMove);
        for (int i = 0; i < 60; i++)
        {
            Stroke bigStroke = new Stroke();
            for (int l = 0; l < 60; l++)
            {
                bigStroke.StylusPoints.Add(new StylusPoint(i, l));               
            }
            inkP.Strokes.Add(bigStroke);
        }
    }
