    public static class VersionExtensions
    {
        public static string GetFileVersion(this Assembly assembly)
        {
            var value = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)
                                .OfType<AssemblyFileVersionAttribute>()
                                .SingleOrDefault();
            return value != null ? value.Version : "?.?.?.?";
        }
        public static string GetCommonFileVersion()
        {
            var assembly = Assembly.GetAssembly(typeof(Common.Web.VersionExtensions));
            var value = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)
                                .OfType<AssemblyFileVersionAttribute>()
                                .SingleOrDefault();
            return value != null ? value.Version : "?.?.?.?";
        }
