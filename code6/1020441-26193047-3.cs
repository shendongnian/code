    public class MyModel : INotifyPropertyChanged
{
...
	private string _errorMessage;
	public string ErrorMessage
        {
            private set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
            get { return _errorMessage;; }
        }
