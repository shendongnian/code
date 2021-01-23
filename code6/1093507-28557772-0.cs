    public class Visitor
    {
        public String Name { get; set; }        
        public int VisitorNo { get; set; }
    }
 
    public partial class MainWindow : Window
    {
        public ObservableCollection<Visitor> ListVisitors { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ListVisitors=new ObservableCollection<Visitor>()
            {
                new Visitor()
                {
                    Name = "name1",                    
                    VisitorNo=21
                },
                 new Visitor()
                {
                    Name = "name2",                    
                    VisitorNo=21
                },
                 new Visitor()
                {
                    Name = "name3",                    
                    VisitorNo=21
                }
            };
        }
        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listVisitor.SelectedItem!=null)
            {
                var dialogBox = new Viewlist((Visitor)listVisitor.SelectedItem);
                var dialogResult = dialogBox.ShowDialog();
            }
            
        }
    }
