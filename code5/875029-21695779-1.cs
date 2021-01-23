    public partial class BindGridColumns : Window {
        private ObservableCollection<object> ItemsList;
    
        public BindGridColumns() {
          InitializeComponent();
    
          ItemsList = new ObservableCollection<object>();
    
          for (int i = 0; i < 7; i++)
          {
            ItemsList.Add(new
           {
             Index = i,
             Margin = new Thickness(0, 60 * i, 0, 0),
             ColumnIndex = ColumnIndex(i),
           });
          }
    
          this.DataContext = ItemsList;
        }
    
        private int ColumnIndex(int i) {
          //Purpose: Place every third item the third column
          if (i % 3 == 0) return 2;
          return 0;
        }
      }
