    public Mypage()
        {
            this.Loaded += (s, e) =>
            {
                mainRow.MaxHeight = mainRow.ActualHeight;
                mainRow.Height = new GridLength(mainRow.ActualHeight, GridUnitType.Pixel);             
            };
            this.InitializeComponent();
            //Stuff
        }
