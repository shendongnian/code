        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Product product1 = new Product() { ID = 1, Name = "Product1" };
            product1.ItemsCollection.Add(new Item() { ID = 1, Date = DateTime.Now});
            product1.ItemsCollection.Add(new Item() { ID = 2, Date = DateTime.Now.AddDays(-1) });
            Product product2 = new Product() { ID = 2, Name = "Product2" };
            product2.ItemsCollection.Add(new Item() { ID = 3, Date = DateTime.Now });
            product2.ItemsCollection.Add(new Item() { ID = 4, Date = DateTime.Now.AddDays(-2) });
            ProductsCollection.Add(product1);
            ProductsCollection.Add(product2);
        }
