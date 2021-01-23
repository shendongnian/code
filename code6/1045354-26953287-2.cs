    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var root = new Item
            {
                Name = "root",
                Children = new ItemCollection(new[]
                {
                    new Item
                    {
                        Name = "item1.1",
                        Children = new ItemCollection(new[]
                        {
                            new Item {Name = "item1.1.1"},
                            new Item {Name = "item1.1.2"}
                        })
                    },
                    new Item
                    {
                        Name = "item1.2",
                        Children = new ItemCollection(new[]
                        {
                            new Item {Name = "item1.2.1"}
                        })
                    },
                    new Item {Name = "item1.3"}
                })
            };
            var item1411 = new Item
            {
                Name = "item1.4.1.1"
            };
            var item141 = new Item
            {
                Name = "item1.4.1",
                Children = new ItemCollection(new[]
                {
                    item1411
                })
            };
            var item14 = new Item
            {
                Name = "item1.4",
                Children = new ItemCollection(new[]
                {
                    item141
                })
            };
            root.Children.Add(item14);
            Console.WriteLine("-----------------");
            Console.WriteLine("before pruning");
            Console.WriteLine("-----------------");
            PrintHierarchy(root);
            Console.WriteLine("-----------------");
            Console.WriteLine("after pruning");
            Console.WriteLine("-----------------");
            item1411.Prune();
            PrintHierarchy(root);
            DataContext = root;
        }
        private void PrintHierarchy(Item root, int level = 0)
        {
            Console.WriteLine("{0}{1}", string.Concat(Enumerable.Repeat(" ", level)), root);
            if (root.Children.Count > 0)
            {
                foreach (Item child in root.Children)
                {
                    PrintHierarchy(child, level + 1);
                }
            }
        }
    }
