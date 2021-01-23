    /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                _dataItems = GetDataItems();
            }
    
            private ObservableCollection<Combination> GetDataItems()
            {
                //Here load all of your individual data structure
                //Eg
                var items = new List<Combination>
                                {
                                    new Combination(new Bank {AccountNo = 112, AccountName = "somename"},
                                                    new Cheque {ChequeDate = DateTime.Now, ChequeNo = 234562}),
                                    new Combination(new Bank {AccountNo = 132, AccountName = "name"},
                                                    new Cheque {ChequeDate = DateTime.Now, ChequeNo = 215562}),
                                    new Combination(new Bank {AccountNo = 212, AccountName = "someother"},
                                                    new Cheque {ChequeDate = DateTime.Now, ChequeNo = 114562})
                                };
    
                return new ObservableCollection<Combination>(items);
            }
    
            private ObservableCollection<Combination> _dataItems;
    
            public ObservableCollection<Combination> DataItems
            {
                get { return _dataItems; }
                set { _dataItems = value; }
            }
        }
    
        public class Combination
        {
            public Combination(Bank bk, Cheque cq)
            {
                ChequeNo = cq.ChequeNo;
                ChequeDate = cq.ChequeDate;
                AccountName = bk.AccountName;
                AccountNo = bk.AccountNo;
            }
    
            public int ChequeNo { get; set; }
            public DateTime ChequeDate { get; set; }
            public int AccountNo { get; set; }
            public String AccountName { get; set; }
        }
    
        public class Cheque
        {
            public int ChequeNo { get; set; }
            public DateTime ChequeDate { get; set; }
        }
    
        public class Bank
        {
            public int AccountNo { get; set; }
            public String AccountName { get; set; }
        }
