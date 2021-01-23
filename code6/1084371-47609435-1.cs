    public static class PatchExtensions
    {
        /// <summary>
        /// Get the properties of a type that are non-editable.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IList<string> NonEditableProperties(this Type type)
        {
            return type.GetProperties().Where(x => Attribute.IsDefined(x, typeof(NonEditableAttribute))).Select(prop => prop.Name).ToList();
        }
        /// <summary>
        /// Get this list of non-editable changes in a <see cref="Delta{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delta"></param>
        /// <returns></returns>
        public static IList<string> NonEditableChanges<T>(this Delta<T> delta)
            where T : class
        {
            var nec = new List<string>();
            var excluded = typeof(T).NonEditableProperties();
            nec.AddRange(delta.GetChangedPropertyNames().Where(x => excluded.Contains(x)));
            return nec;
        }
        /// <summary>
        /// Exclude changes from a <see cref="Delta{T}"/> based on a list of property names
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delta"></param>
        /// <param name="excluded"></param>
        /// <returns></returns>
        public static Delta<T> Exclude<T>(this Delta<T> delta, IList<string> excluded)
            where T : class
        {
            var changed = new Delta<T>();
            foreach (var prop in delta.GetChangedPropertyNames().Where(x => !excluded.Contains(x)))
            {
                object value;
                if (delta.TryGetPropertyValue(prop, out value))
                {
                    changed.TrySetPropertyValue(prop, value);
                }
            }
            return changed;
        }
        /// <summary>
        /// Exclude changes from a <see cref="Delta{T}"/> where the properties are marked with <see cref="NonEditableAttribute"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delta"></param>
        /// <returns></returns>
        public static Delta<T> ExcludeNonEditable<T>(this Delta<T> delta)
            where T : class
        {
            var excluded = typeof(T).NonEditableProperties();
            return delta.Exclude(excluded);
        }
    }
