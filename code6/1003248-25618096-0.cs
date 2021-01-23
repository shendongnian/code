    public class MefMuiBootstrapper : MefBootstrapper
    {
      protected override void ConfigureContainer()
      {
        base.ConfigureContainer();
        Container.ComposeExportedValue( Container );
      }
    }
