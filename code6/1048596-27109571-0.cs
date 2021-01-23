    public class ValidatingModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly List<ValidationResult> _validationResults;
        private readonly ReadOnlyCollection<ValidationResult> _validationResultsView;
        private readonly Dictionary<string, string> _validationErrors;
        private string _compositeMessage;
        private bool _validationPending = true;
        public ValidatingModel()
        {
            _validationResults = new List<ValidationResult>();
            _validationErrors = new Dictionary<string, string>();
            _validationResultsView = new ReadOnlyCollection<ValidationResult>(_validationResults);
        }
        protected ReadOnlyCollection<ValidationResult> ValidationResults
        {
            get { return _validationResultsView; }
        }
        protected void Validate()
        {
            _compositeMessage = null;
            _validationPending = false;
            _validationErrors.Clear();
            _validationResults.Clear();
            var results = Validation.Validate(this);
            foreach (var result in results)
            {
                _validationResults.Add(result);
                _validationErrors[result.Key] = result.Message;
            }
        }
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (_validationPending)
                    Validate();
                
                string message;
                if (_validationErrors.TryGetValue(columnName, out message))
                    return message;
                return null;
            }
        }
        string IDataErrorInfo.Error
        {
            get
            {
                if (_validationPending)
                    Validate();
                if (_compositeMessage != null)
                    return _compositeMessage;
                if (_validationErrors.Count == 0)
                    return null;
                _compositeMessage = _validationErrors.Aggregate(
                    new StringBuilder(), 
                    (sb, p) => (sb.Length > 0 ? sb.AppendLine() : sb).Append(p.Value), 
                    sb => sb.ToString());
                return _compositeMessage;
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            Validate();
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
