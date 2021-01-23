    public class DataService
    {
      private IEnumerable<IDataInstaller> _dataInstallers;
      public DataService(IEnumerable<IDataInstaller> dataInstallers) {
        _dataInstallers = dataInstallers;
      }
      public void Install() {
        foreach (var installer in _dataInstallers)
          installer.InstallData();
      }
    }
