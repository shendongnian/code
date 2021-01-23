    [assembly: Xamarin.Forms.Dependency(typeof(DroidReflectionHelper))]
    namespace App1.Droid
    {
        /// <summary>
        /// Implementation of the <see cref="IReflectionHelper"/> for Android platform.
        /// </summary>
        public class DroidReflectionHelper : IReflectionHelper
        {
            /// <summary>
            /// Get <see cref="MethodInfo"/> for the given type.
            /// </summary>
            /// <param name="type">The type.</param>
            /// <param name="methodName">The name of the method.</param>
            /// <returns>Returns method info.</returns>
            public MethodInfo GetMethodInfo(Type type, string methodName)
            {
                MethodInfo methodInfo = type.GetMethod(methodName);
                return methodInfo;
            }
        }
    }
