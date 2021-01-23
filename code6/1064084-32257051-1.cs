    namespace IM.Common.UIControls
    {
    	public partial class IMTextBox : UserControl
    	{
    		public IMTextBox()
    		{
    			InitializeComponent();
    			Errors = new ObservableCollection<ValidationError>();
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
    		public static DependencyProperty TxtProperty = DependencyProperty.Register("Txt", typeof(string), typeof(IMTextBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PropertyChangedCallback, null , false, UpdateSourceTrigger.PropertyChanged));
    
    		public ObservableCollection<ValidationError> Errors { get; private set; } 
    
    		private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    		{
    			var imTextBox = (dependencyObject as IMTextBox);
    			ReadOnlyObservableCollection<ValidationError> readOnlyObservableCollection = Validation.GetErrors(imTextBox);
    
    			imTextBox.Errors.Clear();
    			foreach (var validationError in readOnlyObservableCollection)
    			{
    				imTextBox.Errors.Add(validationError);
    			}
    		}
    	}
    }
