    public class MyViewModel : ValidatableBase
    {
        [Required]
        public string SomeProperty
        {
            get { return _someProperty; }
            set { SetProperty(ref _someProperty, value); }
        }
    }
    public abstract class ValidatableBase : BindableBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, string> _propertyErrors = new Dictionary<string, string>();
        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            var result = base.SetProperty(ref storage, value, propertyName);
            var error = ValidateProperty(propertyName, value);
            SetError(propertyName, error);
            return result;
        }
        private void SetError(string propertyName, string error, bool notify = false)
        {
            string existingError;
            _propertyErrors.TryGetValue(propertyName, out existingError);
            if (error == null)
            {
                if (existingError != null) _propertyErrors.Remove(propertyName);
            }
            else
            {
                _propertyErrors[propertyName] = error;
            }
            if (existingError != error)
            {
                OnErrorsChanged(propertyName);
            }
        }
        public virtual bool Validate()
        {
            var properties = TypeDescriptor.GetProperties(this);
            foreach (PropertyDescriptor property in properties)
            {
                var error = ValidateProperty(property.Name, property.GetValue(this));
                SetError(property.Name, error, true);
            }
            return HasErrors;
        }
        public void Validate(string propertyName, object value)
        {
            var error = ValidateProperty(propertyName, value);
            SetError(propertyName, error, true);
        }
        protected virtual string ValidateProperty(string propertyName, object value)
        {
            if (propertyName == null) throw new ArgumentNullException("propertyName");
            var validationContext = new ValidationContext(this);
            validationContext.MemberName = propertyName;
            var validationResults = new List<ValidationResult>();
            if (Validator.TryValidateProperty(value, validationContext, validationResults))
            {
                return null;
            }
            return validationResults[0].ErrorMessage;
        }
        protected virtual void OnErrorsChanged(string propertyName)
        {
            var handler = ErrorsChanged;
            if (handler != null) handler(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) yield break;
            string existingError;
            if (_propertyErrors.TryGetValue(propertyName, out existingError))
            {
                yield return existingError;
            }
        }
        public bool HasErrors
        {
            get { return _propertyErrors.Count > 0; }
        }
    }
}
