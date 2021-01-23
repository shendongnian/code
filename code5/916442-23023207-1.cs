    public partial class ListBoxSample : UserControl
    {
        public ListBoxSample()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            Task.Factory.StartNew(() =>
            {
                var list = new List<DataItem>();
                for (int i = 0; i < 100000; i++)
                {
                    var item = new DataItem()
                    {
                        From = "1",
                        To = "2",
                        ChildItems =
                        {
                            new ChildItem()
                            {
                                DependeeFrom = i.ToString(),
                                DependeeTo = (i + 10).ToString(),
                                XXXX = "XXXX"
                            },
                            new ChildItem()
                            {
                                DependeeFrom = i.ToString(),
                                DependeeTo = (i + 10).ToString(),
                                XXXX = "XXXX"
                            },
                            new ChildItem()
                            {
                                DependeeFrom = i.ToString(),
                                DependeeTo = (i + 10).ToString(),
                                XXXX = "XXXX"
                            }
                        }
                    };
                    list.Add(item);
                }
                return list;
            }).ContinueWith(t =>
            {
                Dispatcher.Invoke((Action) (() => DataContext = t.Result));
            });
        }
        private void Load_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadData();
        }
    }
