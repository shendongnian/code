    LookUpEdit ledMyControl;
    RepositoryItemLookUpEdit _myRepositoryLookup;
    RepositoryItemButtonEdit rbtnEdit;
    GridControl grid;
    GridView view;
    GridView detailView;
    GridLevelNode detailNode;
    List<Category> categories = new List<Category>();
    public GridRepositoryItemTest()
    {
        InitializeComponent();
        CreateLookupEdit();
        InitializeGrid();
        SetRepositoryLoopEdit();
        InitializeAndAddColumnsToViews();
     
        InitializeAndBindDataSource();
    
        detailView.Columns["Category"].ColumnEdit = _myRepositoryLookup;            
    }
    
    private void CreateLookupEdit()
    {
        ledMyControl = new LookUpEdit();
        ledMyControl.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key"));
        ledMyControl.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value"));
    
        this.Controls.Add(ledMyControl);
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("Test", "1");
        dic.Add("Test2", "2");
        dic.Add("Test3", "3");
        dic.Add("Test4", "4");
        dic.Add("Test5", "5");
        dic.Add("Test6", "6");
        dic.Add("Test7", "7");
        dic.Add("Test8", "8");
        dic.Add("Test9", "9");
        dic.Add("Test10", "10"); ledMyControl.Properties.DisplayMember = "Value";
        ledMyControl.Properties.ValueMember = "Key";
        ledMyControl.Properties.DataSource = dic.ToList();
    
        ledMyControl.Properties.Columns[0].Visible = false;
    }
    
    private void InitializeGrid()
    {
        grid = new GridControl();
        view = new GridView(grid);
        detailView = new GridView(grid);
        detailNode = grid.LevelTree.Nodes.Add("Books", detailView);
        grid.Dock = DockStyle.Fill;
        this.Controls.Add(grid);
        detailView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(detailView_ValidateRow);
    
    }
    
    void detailView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
    {
        MessageBox.Show("It's working");
    }        
    
    private void InitializeAndAddColumnsToViews()
    {
        if (view != null && detailView != null)
        {
            view.Columns.AddField("CategoryID").VisibleIndex = 0;
            detailView.Columns.AddField("ID").VisibleIndex = 0;
            detailView.Columns.AddField("Name").VisibleIndex = 1;
            detailView.Columns.AddField("Category").VisibleIndex = 2;                    
        }
    }
    
    private void InitializeAndBindDataSource()
    {
        CreateCategories();
        BindingList<BookDetail> bookDetails = new BindingList<BookDetail>();
    
        BookDetail bookDetail = null;
        for (int j = 0; j < 5; j++)
        {
            bookDetail = new BookDetail { CategoryID = categories[j].ID };
            for (int i = 0; i < 5; i++)
            {
                bookDetail.Books.Add(new Book
                {
                    ID = 1,
                    Name = "Book - " + (i + 1),
                    Category = categories[j].ID
                });
            }
            bookDetails.Add(bookDetail);
        }
        grid.DataSource = bookDetails;
    }
    
    private void CreateCategories()
    {
        for (int i = 1; i <= 10; i++)
        {
            categories.Add(new Category
            {
                ID = i,
                Name = "Category - " + i
            });
        }
    }
    
    private void SetRepositoryLoopEdit()
    {
        //rbtnEdit.Click += new EventHandler(rbtnEdit_Click);
        //rbtnEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(rbtnEdit_ButtonClick);
        _myRepositoryLookup = new RepositoryItemLookUpEdit();
        _myRepositoryLookup.Name = "redCategories";
        _myRepositoryLookup.DataSource = categories;
        _myRepositoryLookup.ValueMember = "ID";
        _myRepositoryLookup.DisplayMember = "Name";
        grid.RepositoryItems.Add(_myRepositoryLookup);         
        _myRepositoryLookup.EditValueChanged += new EventHandler(_myRepositoryLookup_EditValueChanged);               
       
    }
    
    void rbtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
        throw new NotImplementedException();
    }
    
    void rbtnEdit_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    
    void _myRepositoryLookup_EditValueChanged(object sender, EventArgs e)
    {
        //your code here
    }
