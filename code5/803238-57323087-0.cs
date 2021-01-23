       private string JavaHome
        {
            get
            {
#if !NETSTANDARD
                string javaHome;
                if (TryGetJavaHome(RegistryView.Default, JavaVendor, JavaInstallation, out javaHome))
                    return javaHome;
                if (TryGetJavaHome(RegistryView.Registry64, JavaVendor, JavaInstallation, out javaHome))
                    return javaHome;
                if (TryGetJavaHome(RegistryView.Registry32, JavaVendor, JavaInstallation, out javaHome))
                    return javaHome;
#endif
                if (Directory.Exists(Environment.GetEnvironmentVariable("JAVA_HOME")))
                    return Environment.GetEnvironmentVariable("JAVA_HOME");
                throw new NotSupportedException("Could not locate a Java installation.");
            }
        }
#if !NETSTANDARD
        private static bool TryGetJavaHome(RegistryView registryView, string vendor, string installation, out string javaHome)
        {
            javaHome = null;
            string javaKeyName = "SOFTWARE\\" + vendor + "\\" + installation;
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                using (RegistryKey javaKey = baseKey.OpenSubKey(javaKeyName))
                {
                    if (javaKey == null)
                        return false;
                    object currentVersion = javaKey.GetValue("CurrentVersion");
                    if (currentVersion == null)
                        return false;
                    using (var homeKey = javaKey.OpenSubKey(currentVersion.ToString()))
                    {
                        if (homeKey == null || homeKey.GetValue("JavaHome") == null)
                            return false;
                        javaHome = homeKey.GetValue("JavaHome").ToString();
                        return !string.IsNullOrEmpty(javaHome);
                    }
                }
            }
        }
#endif
Your `.\packages\Antlr4.CodeGenerator.4.6.3\build\Antlr4.CodeGenerator.targets` file (adjust for correct version number) has lines to set the `JavaVendor` and `JavaInstallation` variables:
    <Antlr4JavaVendor Condition="'$(Antlr4JavaVendor)'==''">JavaSoft</Antlr4JavaVendor>
    <Antlr4JavaInstallation Condition="'$(Antlr4JavaInstallation)'==''">Java Runtime Environment</Antlr4JavaInstallation>
So, in my case at least, the appropriate registry settings were located in `HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Runtime Environment`
To fix the incorrect registry:
- Ensure that `CurrentVersion`'s value (in my case `1.8.0_91`) has a corresponding key 
- Ensure that the `JavaHome` key in `HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Runtime Environment\1.8.0_91` (replace with your version) has a directory path to a valid Java installation.
- If you're running a 64b Windows, ensure this for both the 64b and 32b versions of the registry (see https://support.microsoft.com/fr-dz/help/305097/how-to-view-the-system-registry-by-using-64-bit-versions-of-windows for how to view the 32b registry on a 64b machine).
Keep in mind, that Visual Studio is a 32b process and that, by default, it will run Antlr4 by looking for a 32b version of the JRE.  If, for some reason, you're building the solution outside of Visual Studio with 64b processes, the 64b version of the registry is used.
