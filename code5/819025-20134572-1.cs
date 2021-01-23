    public MainPage()
    {
        this.InitializeComponent();
        var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        timer.Tick += (s, e) => Move();
        timer.Start();
    }
    void Move()
    {
        var ads = new Rectangle[] { Ad1, Ad2, Ad3, Ad4, Ad5, Ad6, Ad7 };
        foreach (var item in ads)
        {
            var row = (int)item.GetValue(Grid.RowProperty);
            var col = (int)item.GetValue(Grid.ColumnProperty);
            if (row == 3)
            {
                if (col == 0)
                {
                    row = 0;
                    col = 3;
                }
                else
                    col--;
            }
            else
            {
                if (row == 2)
                {
                    row = 3;
                    col = 2;
                }
                else
                    row++;
            }
            item.SetValue(Grid.RowProperty, row);
            item.SetValue(Grid.ColumnProperty, col);
        }
    }
