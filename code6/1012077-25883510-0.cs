    public static void SetProperty<T, TProperty>(this T instance, Expression<Func<T, TProperty>> selector, TProperty newValue)
       where T : class
        {            
            var propertyInfo = selector.GetMember() as PropertyInfo;
            instance.GetType().GetProperty(propertyInfo.Name).SetValue(instance, newValue, null);
        }
