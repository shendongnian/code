            var tb = new TextBox();
            tb.SetValue(NameProperty, "contentBox");
            tb.AcceptsReturn = true;
            var b = new Binding("Content");
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(tb, TextBox.TextProperty, b);
