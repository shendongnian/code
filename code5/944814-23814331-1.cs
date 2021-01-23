    namespace WpfApplication1
    {
        public partial class MainWindow 
        {
            public List<MyRow> ListBoxData { get; set; } 
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                ListBoxData = new List<MyRow>
                {
                    new MyRow{Text1 = "Row 1 - Data 1", Text2 = "Row 1 - Data 2"},
                    new MyRow{Text1 = "Row 2 - Data 1", Text2 = "Row 2 - Data 2"},
                    new MyRow{Text1 = "Row 3 - Data 1", Text2 = "Row 3 - Data 2"}
                };
            }
        }       
    
        public class MyRow
        {
            public string Text1 { get; set; }
            public string Text2 { get; set; }
        }
    }
