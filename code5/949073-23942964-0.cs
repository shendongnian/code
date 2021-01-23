    Binding b = new Binding();
    b.Path = new PropertyPath("Image"); // Image should be a public property in your datacontext
    b.Source = dataContext;
    myBorder.SetBinding(Border.BackgroundProperty, b);
    dataContext.Image = new WriteableBitmap(1, 1);
    dataContext.Image.SetSource(e.ChosenPhoto);
    RaiseProperty("Image"); //raise property change
