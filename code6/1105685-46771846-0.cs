    using System;
    
    /// <summary>
    /// Extension methods for <see cref="ConsoleKeyInfo"/>
    /// </summary>
    public static class ConsoleKeyInfoExtensions
    {
        /// <summary>
        /// Attempts to cast the <see cref="ConsoleKeyInfo.KeyChar"/> value from the <paramref name="instance"/> to <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The generic type to cast to.</typeparam>
        /// <param name="instance">The <see cref="ConsoleKeyInfo"/> to extract the value from</param>
        /// <returns>Returns the value in the <see cref="ConsoleKeyInfo.KeyChar"/> as <typeparamref name="T"/></returns>
        /// <exception cref="InvalidCastException">If there is an issue with the casting.  For example, boolean is not valid.</exception>
        /// <exception cref="ArgumentNullException">If the <paramref name="instance"/> is null.</exception>
        public static T GetValue<T>(this ConsoleKeyInfo instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));
    
            var stringValue = instance.KeyChar.ToString();
    
            try
            {
                return (T)Convert.ChangeType(stringValue, typeof(T));
            }
            catch
            {
                throw new InvalidCastException($"Unable to cast a {nameof(ConsoleKeyInfo.KeyChar)} to a type of {typeof(T).FullName}.");
            }
        }
    }
