    namespace Microsoft.AspNetCore.Hosting
    {
      /// <summary>Commonly used environment names.</summary>
      public static class EnvironmentName
      {
        public static readonly string Development = "Development";
        public static readonly string Staging = "Staging";
        public static readonly string Production = "Production";
      }
    }
    namespace Microsoft.AspNetCore.Hosting
    {
      /// <summary>
      /// Extension methods for <see cref="T:Microsoft.AspNetCore.Hosting.IHostingEnvironment" />.
      /// </summary>
      public static class HostingEnvironmentExtensions
      {
        /// <summary>
        /// Checks if the current hosting environment name is "Development".
        /// </summary>
        /// <param name="hostingEnvironment">An instance of <see cref="T:Microsoft.AspNetCore.Hosting.IHostingEnvironment" />.</param>
        /// <returns>True if the environment name is "Development", otherwise false.</returns>
        public static bool IsDevelopment(this IHostingEnvironment hostingEnvironment)
        {
          if (hostingEnvironment == null)
            throw new ArgumentNullException("hostingEnvironment");
          return hostingEnvironment.IsEnvironment(EnvironmentName.Development);
        }
    
        /// <summary>
        /// Checks if the current hosting environment name is "Staging".
        /// </summary>
        /// <param name="hostingEnvironment">An instance of <see cref="T:Microsoft.AspNetCore.Hosting.IHostingEnvironment" />.</param>
        /// <returns>True if the environment name is "Staging", otherwise false.</returns>
        public static bool IsStaging(this IHostingEnvironment hostingEnvironment)
        {
          if (hostingEnvironment == null)
            throw new ArgumentNullException("hostingEnvironment");
          return hostingEnvironment.IsEnvironment(EnvironmentName.Staging);
        }
    
        /// <summary>
        /// Checks if the current hosting environment name is "Production".
        /// </summary>
        /// <param name="hostingEnvironment">An instance of <see cref="T:Microsoft.AspNetCore.Hosting.IHostingEnvironment" />.</param>
        /// <returns>True if the environment name is "Production", otherwise false.</returns>
        public static bool IsProduction(this IHostingEnvironment hostingEnvironment)
        {
          if (hostingEnvironment == null)
            throw new ArgumentNullException("hostingEnvironment");
          return hostingEnvironment.IsEnvironment(EnvironmentName.Production);
        }
    
        /// <summary>
        /// Compares the current hosting environment name against the specified value.
        /// </summary>
        /// <param name="hostingEnvironment">An instance of <see cref="T:Microsoft.AspNetCore.Hosting.IHostingEnvironment" />.</param>
        /// <param name="environmentName">Environment name to validate against.</param>
        /// <returns>True if the specified name is the same as the current environment, otherwise false.</returns>
        public static bool IsEnvironment(this IHostingEnvironment hostingEnvironment, string environmentName)
        {
          if (hostingEnvironment == null)
            throw new ArgumentNullException("hostingEnvironment");
          return string.Equals(hostingEnvironment.EnvironmentName, environmentName, StringComparison.OrdinalIgnoreCase);
        }
      }
    }
