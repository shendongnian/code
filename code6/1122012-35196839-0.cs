    public static class DynamicParameterExtension
    {
        public static T GetUnboundValue<TCmdlet, T>(this TCmdlet cmdlet, string paramName, int unnamedPosition = -1)
        {
            var context = TryGetProperty(cmdlet, "Context");
            var processor = TryGetProperty(context, "CurrentCommandProcessor");
            var parameterBinder = TryGetProperty(processor, "CmdletParameterBinderController");
            var args = TryGetProperty(parameterBinder, "UnboundArguments") as System.Collections.IEnumerable;
            if (args != null)
            {
                var isSwitch = typeof(SwitchParameter) == typeof(T);
                var currentParameterName = string.Empty;
                object unnamedValue = null;
                var i = 0;
                foreach (var arg in args)
                {
                    var isParameterName = TryGetProperty(arg, "ParameterNameSpecified");
                    if (isParameterName != null && true.Equals(isParameterName))
                    {
                        var parameterName = TryGetProperty(arg, "ParameterName") as string;
                        currentParameterName = parameterName;
                        if (isSwitch && string.Equals(currentParameterName, paramName, StringComparison.OrdinalIgnoreCase))
                        {
                            return (T)(object)new SwitchParameter(true);
                        }
                        continue;
                    }
                    var parameterValue = TryGetProperty(arg, "ArgumentValue");
                    if (currentParameterName != string.Empty)
                    {
                        if (string.Equals(currentParameterName, paramName, StringComparison.OrdinalIgnoreCase))
                        {
                            return ConvertParameter<T>(parameterValue);
                        }
                    }
                    else if (i++ == unnamedPosition)
                    {
                        unnamedValue = parameterValue;
                    }
                    currentParameterName = string.Empty;
                }
                if (unnamedValue != null)
                {
                    return ConvertParameter<T>(unnamedValue);
                }
            }
            return default(T);
        }
        public static T GetUnboundValue<TCmdlet, T>(this TCmdlet cmdlet, Expression<Func<TCmdlet, T>> propertyAccess, int unnamedPosition = -1)
        {
            return cmdlet.GetUnboundValue<TCmdlet, T>(GetPropertyName(propertyAccess), unnamedPosition);
        }
        public static T ConvertParameter<T>(this object value)
        {
            if (Equals(value, default(T)))
            {
                return default(T);
            }
            if (value is T)
            {
                return (T)value;
            }
            var constructorInfo = typeof(T).GetConstructor(new[] { value.GetType() });
            if (constructorInfo != null)
            {
                return (T)constructorInfo.Invoke(new[] { value });
            }
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        static object TryGetProperty(object instance, string fieldName)
        {
            if (instance == null || string.IsNullOrEmpty(fieldName))
            {
                return null;
            }
            const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;
            var propertyInfo = instance.GetType().GetProperty(fieldName, bindingFlags);
            try
            {
                if (propertyInfo != null)
                {
                    return propertyInfo.GetValue(instance, null);
                }
                var fieldInfo = instance.GetType().GetField(fieldName, bindingFlags);
                return fieldInfo?.GetValue(instance);
            }
            catch (Exception)
            {
                return null;
            }
        }
        static string GetPropertyName<T, TParam>(Expression<Func<T, TParam>> propertyAccess)
        {
            var body = (MemberExpression)propertyAccess.Body;
            return body.Member.Name;
        }
    }
