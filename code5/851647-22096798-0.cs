    private static void LoadAssemblyFromResources() {
        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {
             try {
                 Assembly asm = Assembly.GetExecutingAssembly();
                 string name = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
                 string rsc = asm.GetManifestResourceNames().FirstOrDefault(s => s.EndsWith(name));
                 if (rsc == null) return null;
                 byte[] module;
                 using (Stream stream = asm.GetManifestResourceStream(rsc)) {
                     if (stream == null) return null;
                     module = new byte[stream.Length];
                     stream.Read(module, 0, module.Length);
                 }
                 try {
                     return Assembly.Load(module);
                 } catch (FileLoadException) {
                     string file = Path.Combine(Path.GetTempPath(), name);
                     if (!File.Exists(file) || !module.SequenceEqual(File.ReadAllBytes(file)))
                         File.WriteAllBytes(file, module);
                     return Assembly.LoadFile(file);
                 }
             } catch {
                 return null;
             }
         };
     }
