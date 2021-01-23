        Binding b = new Binding("idCounter");
        b.Mode = BindingMode.OneWay;
        b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        myLabel.SetBinding(Label.ContentProperty, b);
        DataContext = this;
