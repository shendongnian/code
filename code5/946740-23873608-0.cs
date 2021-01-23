    void CreateLinks(FrameworkElement fe)
    {
        Uri URI = new Uri("http://google.com");
        TextBlock tb = fe as TextBlock;
        if (tb != null)
        {
            string[] tokens = tb.Text.Split();
            tb.Inlines.Clear();
            foreach (string token in tokens)
            {
                if (token == "Click")
                {
                    Hyperlink link = new Hyperlink { NavigateUri = URI };
                    link.Inlines.Add("Click");
                    tb.Inlines.Add(link);
                }
                else
                {
                    tb.Inlines.Add(token);
                }
                tb.Inlines.Add(" ");
            }
            tb.Inlines.Remove(tb.Inlines.Last());
        }
        else
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(fe); ++i)
            {
                CreateLinks(VisualTreeHelper.GetChild(fe, i) as FrameworkElement);
            }
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        Loaded += (s, a) =>
            {
                FrameworkElement root = XamlReader.Parse("<Grid xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><TextBlock>Click Click Clock Clack Click</TextBlock></Grid>") as FrameworkElement;
                CreateLinks(root);
                grid.Children.Add(root);
            };
    }
