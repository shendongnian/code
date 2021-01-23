    using Expressions = System.Linq.Expressions
    public class Item
    {
        public Item(Int32 quarter, Int32 repeatColumns)
        {
            this.Quarter = quarter;
            this.MyColumns = Enumerable
                .Range(1, repeatColumns)
                .ToList();
        }
        public Int32 Quarter
        {
            get; set;
        }
        public IList<Int32> MyColumns
        {
            get; set;
        }
    }
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Items = GetOriginalItems();
            this.DataContext = this;
            this.ReinitializeColumns();
        }
        private void ReinitializeColumns()
        {
            Expressions.Expression<Func<Item, IEnumerable<Int32>>> exp = 
                obj => 
                    obj.MyColumns;
            this.dataGrid.RegenerateColumns(exp,
                this.Items);
        }
        public IEnumerable<Item> Items
        {
            get;
            private set;
        }
        public IEnumerable<Item> GetOriginalItems()
        {
            return new Item[] 
            {
                new Item(1, 3),
                new Item(2, 2),
                new Item(3, 5),
                new Item(4, 2),
            };
        }
    }
