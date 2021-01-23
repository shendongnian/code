    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _propertyValueStorage;
        #region Constructor
        protected ViewModelBase()
        {
            this._propertyValueStorage = new Dictionary<string, object>();
        }
        #endregion
        protected void SetValue<T>(Expression<Func<T>> property, T value)
        {
            var lambdaExpression = property as LambdaExpression;
            if (lambdaExpression == null)
            {
                throw new ArgumentException("Invalid lambda expression", "Lambda expression return value can't be null");
            }
            var propertyName = this.getPropertyName(lambdaExpression);
            var storedValue = this.getValue<T>(propertyName);
            if (object.Equals(storedValue, value)) return;
            this._propertyValueStorage[propertyName] = value;
            this.OnPropertyChanged(propertyName);
        }
        protected T GetValue<T>(Expression<Func<T>> property)
        {
            var lambdaExpression = property as LambdaExpression;
            if (lambdaExpression == null)
            {
                throw new ArgumentException("Invalid lambda expression", "Lambda expression return value can't be null");
            }
            
            var propertyName = this.getPropertyName(lambdaExpression);
            return getValue<T>(propertyName);
        }
        private T getValue<T>(string propertyName)
        {
            object value;
            if (_propertyValueStorage.TryGetValue(propertyName, out value))
            {
                return (T)value;
            }
            return default(T);
        }
        private string getPropertyName(LambdaExpression lambdaExpression)
        {
            MemberExpression memberExpression;
            if (lambdaExpression.Body is UnaryExpression)
            {
                var unaryExpression = lambdaExpression.Body as UnaryExpression;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambdaExpression.Body as MemberExpression;
            }
            return memberExpression.Member.Name;
        }
        #region < INotifyPropertyChanged > Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
