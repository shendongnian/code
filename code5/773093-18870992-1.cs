    protected double FromNullable(double? value)
    {
      return value.HasValue ? value.Value : double.NaN;
    }
    protected void PropertyChange(ref double? propertyValue, double newValue, [CallerMemberName] string propertyName = "")
    {
      this.PropertyChangeCore(ref propertyValue, double.IsNaN(newValue) ? (double?)null : (double?)newValue, propertyName);
    }
    protected void HandlePropertyCore(ref double? propertyValue, double? newValue, [CallerMemberName] string propertyName = "")
    {
      if ((newValue.HasValue || propertyValue.HasValue) &&    // If both are null than do not fire.
           ((!propertyValue.HasValue || double.IsNaN(propertyValue.Value))
           ^ (!newValue.HasValue || double.IsNaN(newValue.Value))   // If one of them is null or NaN then fire according to XOr rule.
           || Math.Abs(propertyValue.Value - newValue.Value) > double.Epsilon)) // If the are not the same than fire.
      {
        propertyValue = newValue;
        this.HandlePropertyCore(propertyName); // HERE YOU NEED JUST TO HANDLE DOUBLE PROPERTY
      }
    }
