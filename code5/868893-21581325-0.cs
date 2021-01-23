        bool IsDataLoaded = false; //flag
   
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (!IsDataLoaded)
            {
                Lists = new ObservableCollection<myList>();
                myList list1 = new myList() { Name = "First" };
                for (int i = 0; i < 100; i++)
                    list1.Items.Add(new myItems() { Title = (i + 1).ToString() });
                myList list2 = new myList() { Name = "Second" };
                for (int i = 100; i < 200; i++)
                    list2.Items.Add(new myItems() { Title = (i + 1).ToString() });
                myList list3 = new myList() { Name = "Third" };
                for (int i = 200; i < 300; i++)
                    list3.Items.Add(new myItems() { Title = (i + 1).ToString() });
                myList list4 = new myList() { Name = "Fourth" };
                for (int i = 300; i < 400; i++)
                    list4.Items.Add(new myItems() { Title = (i + 1).ToString() });
                Lists.Add(list1);
                Lists.Add(list2);
                Lists.Add(list3);
                Lists.Add(list4);
                myButton.Click += first_Click;
                this.DataContext = this;
                IsDataLoaded = true;
            }
        }
