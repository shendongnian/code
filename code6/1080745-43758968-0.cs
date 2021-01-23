    /// <summary>
    /// This interface provides some reflection methods which are not supported into PCL.
    /// </summary>
        public interface IReflectionHelper
        {
            /// <summary>
            /// Get <see cref="MethodInfo"/> for the given type.
            /// </summary>
            /// <param name="type">The type.</param>
            /// <param name="methodName">The name of the method.</param>
            /// <returns>Returns method info.</returns>
            MethodInfo GetMethodInfo(Type type, string methodName);
        }
