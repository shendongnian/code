    public MyTestControl()
    {
       InitializeComponent();
       Binding b = new Binding("Text");
       b.Source = MyTextBox;
       SetBinding(TextProperty, b);
    }
