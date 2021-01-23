    public class OViewModel
    {
      public IData ThisData { get; set; } //private set??
      
      public OViewModel(IData _thisData)
      {
        ThisData = _thisData;
        InitializeComponent();
      }
    }
