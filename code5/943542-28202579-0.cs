    public class PaymentEditorViewModel() : ValidatingScreen
    {
      public PaymentEditorViewModel()
      {
        AddValidationRule(() => PaymentSum).Condition(() => PaymentSum <= 0).Message("Please enter payment sum");
      }
    
      #region PaymentSum property
      decimal _PaymentSum;
      public decimal PaymentSum
      {
        get
        {
          return _PaymentSum;
        }
        set
        {
          _PaymentSum = value;
          NotifyOfPropertyChange(() => PaymentSum);
        }
      }
      #endregion
    }
