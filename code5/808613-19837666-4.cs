    public wValidationRule()
    {
        InitializeComponent();
        cus.ID = 0;
        stkMain.DataContext = cus;
       
        //trigger the validation.
        lblSource.GetBindingExpression(Label.ContentProperty).UpdateSource();
    }
