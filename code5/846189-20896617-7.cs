    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = Enumerable.Range(0,10)
                                    .Select(x => new DataItem()
                                    {
                                        DisplayName = "Item" + x.ToString(),
                                        IsSelected = x % 2 == 0
                                    });
        }
    }
