    namespace IM.Common.UIControls
    {
    public partial class IMTextBox : UserControl
	{
		public IMTextBox()
		{
			InitializeComponent();
		}
		public string Txt
		{
			get
			{
				return (string)GetValue(TxtProperty);
			}
			set
			{
				SetValue(TxtProperty, value);
			}
		}
		public static DependencyProperty TxtProperty = DependencyProperty.Register("Txt", typeof(string), typeof(IMTextBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, null, false, UpdateSourceTrigger.PropertyChanged));
	}
    }
