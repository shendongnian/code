    // make a constructor in the second form that takes Staff as parameter
    Staff _staff;
    public Payslip(Staff s)
    {
       InitializeComponent();
       _staff = s;
    }
    private void btnCalcPay_Click(object sender, RoutedEventArgs e)
    {
        grossPay = staff1.calcPay();
        taxRate = staff1.calcTaxRate();
        // pass the staff1 instance to constructor when creating the Form 
        Payslip P = new Payslip(staff1); 
        P.Show();
    }
