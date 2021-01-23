    public abstract class BaseObject : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Setter<T>( Action<T> setter, T newVal, Expression<Func<T>> property, params Expression<Func<object>>[] dependentProperties )
            {
            if ( !@equals( getPropValue( property ), newVal ) )
                {
                setter( newVal );
                notifyDepenentProps( property, dependentProperties );
                }
            }
        private static string getPropertyName<Tz>( Expression<Func<Tz>> property )
            {
            return getPropertyInfo( property ).Name;
            }
        private static PropertyInfo getPropertyInfo<T>( Expression<Func<T>> property )
            {
            MemberExpression expression;
            var body = property.Body as UnaryExpression;
            if ( body != null )
                expression = (MemberExpression) body.Operand; //for value types
            else
                expression = ( (MemberExpression) property.Body );
            var pi = expression.Member as PropertyInfo;
            if ( pi == null )
                throw new ArgumentException( "expression must be valid property" );
            return pi;
            }
        private void valueChanged<Ta>( Expression<Func<Ta>> property )
            {
            if ( PropertyChanged != null )
                PropertyChanged( this, new PropertyChangedEventArgs( getPropertyName( property ) ) );
            }
        private void notifyDepenentProps<T>( Expression<Func<T>> property, Expression<Func<object>>[] dependentProps )
            {
            valueChanged( property );
            if ( dependentProps != null && dependentProps.Length > 0 )
                {
                for ( int index = 0; index < dependentProps.Length; index++ )
                    valueChanged( dependentProps[index] );
                }
            }
        private T getPropValue<T>( Expression<Func<T>> property )
            {
            PropertyInfo pi = getPropertyInfo( property );
            return (T) pi.GetValue( this, new object[] {} );
            }
        private bool equals<T>( T first, T second )
            {
            return EqualityComparer<T>.Default.Equals( first, second );
            }
        }
