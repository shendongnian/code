     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<GroupNumber> lstNum = new ObservableCollection<GroupNumber>();
            lstNum.Add(new GroupNumber() { Number=1,Text="Test",Comment="Comment"});
            numGrid.ItemsSource = lstNum;
            ObservableCollection<Groupunit> lstUnit = new ObservableCollection<Groupunit>();
            lstUnit.Add(new Groupunit() { Unit = 2, Text = "Test", Comment = "Comment" });
            unitGrid.ItemsSource = lstUnit;
        }
    }
    public class GroupTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GroupNumber
        { get; set; }
        public DataTemplate GroupUnit
        { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {            
            if (item is GroupNumber)
            {
                return GroupNumber;
            }
            else if (item is Groupunit)
            {
                return GroupUnit;
            }
            else
                return base.SelectTemplate(item, container);
        }
    }
    public class GroupNumber
    {
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private string comment;
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }      
    }
    public class Groupunit
    {
        private int unit;
        public int Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private string comment;
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
