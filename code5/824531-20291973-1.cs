    using System.Linq;
    string[] assemblies = AppDomain
                         .CurrentDomain
                         .GetAssemblies()
                         .Where(a => a.FullName.Contains("MVC"))
                         .Select(a => String.Format(
                            CultureInfo.InvariantCulture,
                            "[{0}] {1}",
                            a.GlobalAssemblyCache,
                            a.FullName
                            ))
                         .ToArray();
    File.WriteAllLines("c:\\assembliesdump.txt", items .ToArray());   
