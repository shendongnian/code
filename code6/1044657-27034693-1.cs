    public ClassB()
    {
        DependencyPropertyDescriptor.FromProperty(MyTextProperty, typeof(ClassB))
            .AddValueChanged(this, MyHandler);
    }
    private void MyHandler(object sender, EventArgs e)
    {
        //your handler code
    }
