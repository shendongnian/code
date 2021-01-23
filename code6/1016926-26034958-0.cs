    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var a = new MyClass ();
           
            var b = new MyClass();
            a.DependentObj = b;
            a.Symbol = "A";
            //b.Symbol = a.Symbol;    // Not work!
            a.Symbol = "B";
            MessageBox.Show(b.Symbol);
        }
        
    }
       public class MyClass
    {
        private MyClass _dependentObj;
        private string _symbol;
        public MyClass DependentObj
        {
            get { return _dependentObj; }
            set
            {
                _dependentObj = value;
                
            }
        }
        
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                //Here add the update code
                if(DependentObj !=null)
                {
                    DependentObj._symbol = value;
                }
            }
        }
    }
