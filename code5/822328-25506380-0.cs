    ((INotifyPropertyChanged)this.ViewData).PropertyChanged += (sender2, e2) =>
        {
            if (e2.PropertyName == "Test")
            {
                bind.ReadValue();
            }
        };
