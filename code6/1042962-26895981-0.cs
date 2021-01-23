    public MyClass()
    {
       this.submitCommand = new DelegateCommand<int?>(this.Submit, this.CanSubmit);
    }
    private bool CanSubmit(int? customerId)
    {
      return (customerId.HasValue && customers.Contains(customerId.Value));
    }
