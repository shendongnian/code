        InitializeComponent();
        TabControl tc = new TabControl();
        tc.Location = new Point(10, 10);
        tc.Size = new Size(100, 100);           
        tc.Visible = true;
        tc.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left |           AnchorStyles.Top);
        this.Controls.Add(tc)
        addImage("c:\pathToImage\image.bmp");
