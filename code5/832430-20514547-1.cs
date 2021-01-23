    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                                       
                Parents = new ObservableCollection<MyTreeItem>();
                var children=new ObservableCollection<MyTreeItem>();
                children.Add(new MyTreeItem(){ Name="child1"});
                children.Add(new MyTreeItem(){ Name="child2"});
                Parents.Add(new MyTreeItem() { Name = "Parent Node", Children = children });
    
                this.DataContext = this;
            }
    
            public ObservableCollection<MyTreeItem> Parents { get; set; }
            
        }
    
        public class MyTreeItem {
            public string Name { get; set; }
            public ObservableCollection<MyTreeItem> Children { get; set; }
        }
