        private void SetParam<T>(IDictionary<string, object> eo, string paramName, T param)
        {
            // is not IEnumerable<>, but it might be not-supported IEnumerable
            if (typeof(T).GetInterfaces().Contains(typeof(System.Collections.IEnumerable)))
                throw new NotSupportedException("Non-generic collection types are not supported");
            // it is just plain not-colection, so set value
            eo[paramName] = param;
        }
        private void SetParam<T>(IDictionary<string, object> eo, string paramName, IEnumerable<T> param)
        {
            if (!eo.ContainsKey(paramName))
                eo[paramName] = param;
            else
                eo[paramName] = (eo[paramName] as IEnumerable<T>).Concat(param);
        }
