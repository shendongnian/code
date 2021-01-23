    public void AddNewAddress()
    {
        using (var ctx = DB.Get())
        {
            ctx.Addresses.Add(SelectedAddress);
            ctx.SaveChanges();
        }
        OnPropertyChanged("SelectedAddress");
    }
