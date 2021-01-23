            protected void RaisePropertyChanged<T>(System.Linq.Expressions.Expression<Func<T>> lambda)
            {
                dynamic l = lambda.Body;
                string propertyName = l.Member.Name;
                OnPropertyChanged(propertyName);
            }
