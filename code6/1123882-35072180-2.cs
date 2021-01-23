     public abstract class UpdateableModel : ViewModelBase
    {
        private static readonly MethodInfo GetPropertyMethod;
        private static readonly MethodInfo SetPropertyMethod;
        private readonly bool _trackingEnabled;
        private readonly Dictionary<string, Tuple<Expression, object>> _originalValues;
        private readonly List<string> _differingFields;
        static UpdateableModel() 
        {
            GetPropertyMethod = typeof(UpdateableModel).GetMethod("GetProperty", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            SetPropertyMethod = typeof(UpdateableModel).GetMethod("SetProperty");
        }
        protected UpdateableModel(bool isNewModel)
        {
            _originalValues = new Dictionary<string, Tuple<Expression, object>>();
            _differingFields = new List<string>();
            if (isNewModel) return;
            State = ModelState.Unmodified;
            _trackingEnabled = true;
        }
        public ModelState State
        {
            get { return GetProperty(() => State); }
            set { base.SetProperty(() => State, value); }
        }
        public new bool SetProperty<T>(Expression<Func<T>> expression, T value)
        {
            var wasUpdated = base.SetProperty(expression, value);
            if (_trackingEnabled && wasUpdated)
            {
                UpdateState(expression, value);
            }
            return wasUpdated;
        }
        /// <summary>
        /// Reset State is meant to be called when discarding changes, it will reset the State value to Unmodified and set all modified values back to their original value.
        /// </summary>
        public void ResetState()
        {
            if (!_trackingEnabled) return;
            foreach (var differingField in _differingFields)
            {
                var type = GetFuncType(_originalValues[differingField].Item1);
                
                var genericPropertySetter = SetPropertyMethod.MakeGenericMethod(type);
                genericPropertySetter.Invoke(this, new[]{_originalValues[differingField].Item2});
            }
        }
        /// <summary>
        /// Update State is meant to be called after changes have been persisted, it will reset the State value to Unmodified and update the original values to the new values.
        /// </summary>
        public void UpdateState()
        {
            if (!_trackingEnabled) return;
            foreach (var differingField in _differingFields)
            {
                var type = GetFuncType(_originalValues[differingField].Item1);
                var genericPropertySetter = GetPropertyMethod.MakeGenericMethod(type);
                var value = genericPropertySetter.Invoke(this, new object[] { _originalValues[differingField].Item1 });
                var newValue = new Tuple<Expression, object>(_originalValues[differingField].Item1,value);
                _originalValues[differingField] = newValue;
            }
            _differingFields.Clear();
            State = ModelState.Unmodified;
        }
        private static Type GetFuncType(Expression expr)
        {
            var lambda = expr as LambdaExpression;
            if (lambda == null)
            {
                return null;
            }
            var member = lambda.Body as MemberExpression;
            return member != null ? member.Type : null;
        }
        private void UpdateState<T>(Expression<Func<T>> expression, T value)
        {
            var propertyName = GetPropertyName(expression);
            if (!_originalValues.ContainsKey(propertyName))
            {
                _originalValues.Add(propertyName, new Tuple<Expression,object>(expression, value));
            }
            
            else
            {
                if (!Compare(_originalValues[propertyName].Item2, value))
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
