    internal class AssemblyResolver
    {
      public static void Register()
      {
        AppDomain.CurrentDomain.AssemblyResolve +=
          (sender, args) =>
          {
            var an = new AssemblyName(args.Name);
            if (an.Name == "YourAssembly")
            {
              string resourcepath = "YourNamespace.YourAssembly.dll";
              Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcepath);
              if (stream != null)
              {
                using (stream)
                {
                  byte[] data = new byte[stream.Length];
                  stream.Read(data, 0, data.Length);
                  return Assembly.Load(data);
                }
              }
            }
            return null;
          }
      }
    }
