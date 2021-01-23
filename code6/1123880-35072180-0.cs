     public abstract class UpdateableModel : ViewModelBase
    {
        private readonly bool _trackingEnabled;
        private readonly Dictionary<string, object> _originalValues;
        private readonly List<string> _differingFields; 
        protected UpdateableModel(bool isNewModel)
        {
            _originalValues = new Dictionary<string, object>();
            _differingFields = new List<string>();
            if (isNewModel) return;
            State = ModelState.Unmodified;
            _trackingEnabled = true;
        }
        public ModelState State { get; private set; }
        public new bool SetProperty<T>(Expression<Func<T>> expression, T value)
        {
            var wasUpdated = base.SetProperty(expression, value);
            if (_trackingEnabled && wasUpdated)
            {
                UpdateState(expression, value);
            }
            return wasUpdated;
        }
        private void UpdateState<T>(Expression<Func<T>> expression, T value)
        {
            var propertyName = GetPropertyName(expression);
            if (!_originalValues.ContainsKey(propertyName))
            {
                _originalValues.Add(propertyName, value);
            }
            else
            {
                if (!Compare(_originalValues[propertyName], value))
                {
                    _differingFields.Add(propertyName);
                }
                else if (_differingFields.Contains(propertyName))
                {
                    _differingFields.Remove(propertyName);                   
                }
                State = _differingFields.Count == 0 
                            ? ModelState.Unmodified 
                            : ModelState.Modified;
            }
        }
        private static bool Compare<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    }
