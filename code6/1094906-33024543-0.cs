    public class DataInstallerA : IDataInstaller {
      public DataInstallerA(SubDependencyA a){}
    }
    public class DataInstallerB : IDataInstaller  {
      public DataInstallerA(SubDependencyB b){}
    }
