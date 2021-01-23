    namespace StackOverflow._21906388
    {
        public class MyNode
        {
            public MyNode()
            {
                Items = new ObservableCollection<MyNode>();
                Property1 = "P1";
                Property2 = "P1";
            }
    
            public string Name { get; set; }
    
            public bool IsLeafNode { get; set; }
    
            [DisplayName("Property 1")]
            public string Property1 { get; set; }
    
            [DisplayName("Property 2")]
            public string Property2 { get; set; }
    
            public ObservableCollection<MyNode> Items { get; set; }
    
            public IEnumerable<MyNode> Properties
            {
                get
                {
                    var list = new List<MyNode>();
    
                    if (IsLeafNode)
                    {
                        var nameBuffer = new StringBuilder();
                        this.GetType().GetProperties().Where(p => p.GetCustomAttribute<DisplayNameAttribute>() != null).ToList()
                            .ForEach(p => nameBuffer.Append(string.Format(" - | {0}: {1}", p.GetCustomAttribute<DisplayNameAttribute>().DisplayName, p.GetValue(this))));
                        list.Add(new MyNode() { Name = nameBuffer.ToString() });
                    }
                    return list;
                }
            }
    
        }
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                this.InitialiseData();
    
                InitializeComponent();
            }
    
            public ObservableCollection<MyNode> Items { get; set; }
    
            public void InitialiseData()
            {
                Items = new ObservableCollection<MyNode>
                {
                    new MyNode
                    {
                        Name = "one",
                        Items = new ObservableCollection<MyNode>
                        {
                            new MyNode { Name = "one", IsLeafNode = true },
                            new MyNode { Name = "two", IsLeafNode = true },
                            new MyNode { Name = "three", IsLeafNode = true }
                        }
                    },
                    new MyNode
                    {
                        Name = "two",
                        Items = new ObservableCollection<MyNode>
                        {
                            new MyNode { Name = "one", IsLeafNode = true },
                            new MyNode { Name = "two", IsLeafNode = true },
                            new MyNode { Name = "three", IsLeafNode = true }
                        }
                    },
                    new MyNode { Name = "three", IsLeafNode = true }
                };
            }
        }
    }
