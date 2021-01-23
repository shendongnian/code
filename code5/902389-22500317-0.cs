    // versionNumber = "0001", "0002" etc
    
    var basePath = Path.GetDirectoryName(typeof(this).Assembly.Location) + "\\Updates\\" + versionNumber + "\\";
    var updateAssemblyPath = Path.Combine(basePath, "Cool.Program.Update" + versionNumber + ".dll");
            
    var setup = AppDomain.CurrentDomain.SetupInformation;
    setup.ApplicationBase = basePath;
    var newDomain = AppDomain.CreateDomain("Updater for " + versionNumber, null, setup);
    var obj = (ICanDoSomething)newDomain.CreateInstanceFromAndUnwrap(updateAssemblyPath, "TestDynamicAssemblyLoading.Update"+ versionNumber + ".Class1");
    var result = obj.TellMeYourVersionsAndDependencyVersions();
    MessageBox.Show(result);
