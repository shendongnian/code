    public static class ExtensionMethod
    {
        public static bool IsMicrosoftAssembly(this Assembly assembly)
        {
            return assembly.GetName().GetPublicKeyToken().SequenceEqual(typeof(int).Assembly.GetName().GetPublicKeyToken());
        }
    }
