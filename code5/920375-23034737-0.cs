    public string Value
    {
        get { return value; }
        set
        {
            int index = ParentVM.Items.IndexOf(this);
            App.Current.Dispatcher.BeginInvoke((Action)delegate  <-- HERE
            {
                ParentVM.Items[index] = new ItemVM(value, ParentVM);
            });
            this.value = value + " in old VM";
    
            var h = PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs("Value"));
            }
        }
    }
