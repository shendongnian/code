        private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("PluginCore1.0"))
            {
                return typeof(IPlugin).Assembly;
            }
            return null;
        }
