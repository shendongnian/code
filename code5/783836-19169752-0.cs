        privatestatic bool TypeHasProperty<P>(Expression<Func<T, P>> accessor)
        {
            var propertyName = ((MemberExpression)accessor.Body).Member.Name;
            var properties = typeof(T).GetProperties();
            var requiredProperty = properties.FirstOrDefault(
                a => a.Name == propertyName);
            if (requiredProperty == null)
            {
                return false;
            }
            ;
            return true;
        }
    }
    class Foo
    {
        public int Baz { get; set; }
    }
