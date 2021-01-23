    [Export(typeof(IView)), PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.Any)]
	[ExportMetadata("Name", "uc1")]
	public partial class myusercontrol : UserControl,IView
	{
		public ServiceContractList()
		{
			InitializeComponent();
		}
    }
  
