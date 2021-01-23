    public partial class MyForm : XtraForm
    {
      public MyForm()
      {
        InitializeComponent();
      }
    
      private List<Product> MyList()
      {
        List<Product> myList = new List<Product>();
        //Add all your Products
      }
    
      private void LoadGrid()
      {
         MyGrid.DataSource = MyList();
      }
    }
