    private MainScreen mainScreen;
     //overloaded constructor with handle to Form1
        public AddItemDialog(MainScreen frm1)
        {
            InitializeComponent();
            mainScreen = frm1;
        }
    private void btnAdd_Click(object sender, EventArgs e)
    {
            MainScreen mainScreen = new MainScreen();
            MessageBox.Show("Item Added!");
            ListViewItem lvi = new ListViewItem();
            lvi.Text = "Item 1";
            lvi.SubItems.Add("Second Item");
            mainScreen.AddFromItemDialog(lvi);
    }
