    public class ValidatingModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly KeyedCollectionBase<string, PropertyInfo> _properties;
        private readonly Dictionary<string, Validator> _propertyValidators;
        private readonly Dictionary<string, ValidationResults> _validationResults;
        private string _compositeMessage;
        public ValidatingModel()
        {
            _properties = new KeyedCollectionBase<string, PropertyInfo>(p => p.Name);
            _propertyValidators = new Dictionary<string, Validator>();
            _validationResults = new Dictionary<string, ValidationResults>();
            PopulateValidators();
        }
        private void PopulateValidators()
        {
            var properties = GetType().GetProperties(
                BindingFlags.Instance |
                BindingFlags.Public);
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(
                    typeof(ValueValidatorAttribute),
                    false);
                if (attributes.Length == 0 || _properties.Contains(property.Name))
                    continue;
                _properties.Add(property);
                _propertyValidators[property.Name] =
                    PropertyValidationFactory.GetPropertyValidatorFromAttributes(
                        property.PropertyType,
                        property,
                        string.Empty,
                        new MemberAccessValidatorBuilderFactory());
            }
        }
        protected IEnumerable<ValidationResult> GetValidationResults()
        {
            foreach (var results in _validationResults.Values)
            {
                foreach (var result in results)
                    yield return result;
            }
        }
        protected IEnumerable<ValidationResult> GetValidationResults(string property)
        {
            if (_propertyValidators.ContainsKey(property))
            {
                ValidationResults results;
                if (!_validationResults.TryGetValue(property, out results))
                    Validate(property);
                if (!_validationResults.TryGetValue(property, out results))
                    yield break;
                foreach (var result in results)
                    yield return result;
            }
        }
        protected void Validate(string propertyName)
        {
            if (_propertyValidators.ContainsKey(propertyName))
            {
                _compositeMessage = null;
                _validationResults[propertyName] = Validation.Validate(this);
            }
        }
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                ValidationResults results;
                if (!_validationResults.TryGetValue(columnName, out results))
                    Validate(columnName);
                if (_validationResults.TryGetValue(columnName, out results))
                    return CombineMessages(results);
                return null;
            }
        }
        string IDataErrorInfo.Error
        {
            get
            {
                if (_compositeMessage != null)
                    return _compositeMessage;
                foreach (var validator in _propertyValidators)
                {
                    if (_validationResults.ContainsKey(validator.Key))
                        continue;
                    _validationResults[validator.Key] = ValidateProperty(
                        validator.Value,
                        _properties[validator.Key]);
                }
                _compositeMessage = CombineMessages(
                    _validationResults.SelectMany(r => r.Value));
                return _compositeMessage;
            }
        }
        private ValidationResults ValidateProperty(
            Validator validator,
            PropertyInfo propertyInfo)
        {
            return validator.Validate(propertyInfo.GetValue(this, null));
        }
        private static string CombineMessages(IEnumerable<ValidationResult> results)
        {
            return results.Aggregate(
                new StringBuilder(),
                (sb, p) => (sb.Length > 0 ? sb.AppendLine() : sb).Append(p.Message),
                sb => sb.ToString());
        }
        protected void OnPropertyChanged(string propertyName)
        {
            Validate(propertyName);
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private sealed class KeyedCollectionBase<TKey, TValue> 
            : KeyedCollection<TKey, TValue>
        {
            private readonly Func<TValue, TKey> _keySelector;
            public KeyedCollectionBase(Func<TValue, TKey> keySelector)
            {
                _keySelector = keySelector;
            }
            protected override TKey GetKeyForItem(TValue item)
            {
                return _keySelector(item);
            }
        }
    }
