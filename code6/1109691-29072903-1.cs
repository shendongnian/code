            <ListBox.ItemTemplate>
                <DataTemplate DataType="ListBoxItem">
                   <CheckBox Content="{Binding name}" IsChecked="{Binding isChecked}"/>
                </DataTemplate>
            </ListBox.ItemTemplate>
.
    public MainWindow()
        {
            InitializeComponent();
            List<MyListBoxItem> names = new List<MyListBoxItem>();
            names.Add(new MyListBoxItem("salim", true));
            listBox1.ItemsSource = names;
        }
        void getCheckedNames()
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (((MyListBoxItem)listBox1.Items[i]).isChecked)
                {
                    // Do things..
                }
            }
        }
        class MyListBoxItem
        {
            public string name { get; set; }
            public bool isChecked { get; set; }
            public MyListBoxItem(string name, bool isChecked)
            {
                this.name = name;
                this.isChecked = isChecked;
            }
        }
