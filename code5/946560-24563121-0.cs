    private void AddNugetPackage(VSProject VsProj, string PackageName, string Version)
        {
          try
          {
            Assembly nugetAssembly = Assembly.Load("nuget.core");
            Type packageRepositoryFactoryType = nugetAssembly.GetType("NuGet.PackageRepositoryFactory");
            PropertyInfo piDefault = packageRepositoryFactoryType.GetProperty("Default");
            MethodInfo miCreateRepository = packageRepositoryFactoryType.GetMethod("CreateRepository");
            object repo = miCreateRepository.Invoke(piDefault.GetValue(null, null), new object[] { "https://packages.nuget.org/api/v2" });
            Type packageManagerType = nugetAssembly.GetType("NuGet.PackageManager");
            ConstructorInfo ciPackageManger = packageManagerType.GetConstructor(new Type[] { System.Reflection.Assembly.Load("nuget.core").GetType("NuGet.IPackageRepository"), typeof(string) });
            DirectoryInfo di = new DirectoryInfo(ProjectPath);
            string solPath = di.Parent.FullName;
            string installPath = di.Parent.CreateSubdirectory("packages").FullName;
            object packageManager = ciPackageManger.Invoke(new object[] { repo, installPath });
            MethodInfo miInstallPackage = packageManagerType.GetMethod("InstallPackage",
              new Type[] { typeof(string), System.Reflection.Assembly.Load("nuget.core").GetType("NuGet.SemanticVersion") });
            string packageID = PackageName;
            MethodInfo miParse = nugetAssembly.GetType("NuGet.SemanticVersion").GetMethod("Parse");
            object semanticVersion = miParse.Invoke(null, new object[] { Version });
            miInstallPackage.Invoke(packageManager, new object[] { packageID, semanticVersion });
          }
          catch(Exception ex)
          { 
            // ...
            return;
          }      
        }
