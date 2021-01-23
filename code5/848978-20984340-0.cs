    public class MainViewModel : BaseViewModel
    {
      …your code here
      private bool _isValid;
      public bool IsValid
      {
        get
        {
          return _isValid;
        }
        set
        {
          _isValid = value;
          RaisePropertyChange("IsValid");
        }
      }
    }
