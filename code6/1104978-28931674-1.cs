     public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            List<Person> lst = new List<Person>();
            listBox.ItemsSource = lst;
            lst.Add(new Person() { FirstName="Test"});
        }
        private void CanExecuteAddCredit(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ExecutedAddCredit(object sender, ExecutedRoutedEventArgs e)
        {
            
        }
        private void CanExecuteAddCreditBlock(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ExecutedAddCreditBlock(object sender, ExecutedRoutedEventArgs e)
        {
        }
    }
    public static class CrawlCommands
    {
        public static readonly RoutedUICommand AddCredit = new RoutedUICommand
                (
                        "AddCredit",
                        "AddCredit",
                        typeof(CrawlCommands)
                );
        public static readonly RoutedUICommand AddCreditBlock = new RoutedUICommand
                (
                        "AddCreditBlock",
                        "AddCreditBlock",
                        typeof(CrawlCommands)
                );
    }
    class Person
    {
        private string myVar;
        public string FirstName
        {
            get { return myVar; }
            set { myVar = value; }
        }
        
    }
