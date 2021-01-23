    [Export]
    public class ViewModel
    {
      private readonly CompositionContainer container;
      [ImportingConstructor]
      public ViewModel( CompositionContainer container )
      {
        this.container = container;
      }
      public void Load()
      {
        var exportedObj = container.GetExportedValue<IRuleFile>();
      }
    }
