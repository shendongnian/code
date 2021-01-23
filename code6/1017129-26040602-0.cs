    frameElementFactory.SetBinding(
        Selector.SelectedValueProperty,
        new Binding {
            Path = new PropertyPath(ContentControl.ContentProperty), // ?
            Mode = BindingMode.TwoWay
        }
    );
