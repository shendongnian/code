    public partial class Payslip : Window
    {
        Staff staff_;
        public Payslip()
        {
            InitializeComponent();
            //Want to be able to access staff1 here ????
        }
        public Payslip(Staff staff)
        {
            InitializeComponent();
            //Want to be able to access staff1 here ????
            staff_ = staff;
        }
    }
