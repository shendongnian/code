    public partial class DeliveryStatusIndicator : UserControl
    {
    	public DeliveryStatusIndicator()
    	{
    			InitializeComponent();		    
    	}
    
        public static readonly DependencyProperty DeliveryDescriptionProperty = DependencyProperty.Register("DeliveryDescription", typeof(string), typeof(DeliveryStatusIndicator), new FrameworkPropertyMetadata("Default", DescriptionChangedEventHandler));
    
         private static void DescriptionChangedEventHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
         {
             ((DeliveryStatusIndicator)d).Desc.Text = (string)e.NewValue;
         }
    
         public string DeliveryDescription
         {
             get { return (string)GetValue(DeliveryDescriptionProperty); }
             set
             {
                 SetValue(DeliveryDescriptionProperty, value);
             }
    
         }
    
         public static readonly DependencyProperty DeliveryStatusProperty = DependencyProperty.Register("DeliveryStatus", typeof(bool), typeof(DeliveryStatusIndicator), new FrameworkPropertyMetadata(false, StatusChangedEventHandler));
    
         private static void StatusChangedEventHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
         {
             ((DeliveryStatusIndicator)d).Indicator.Fill = (bool)e.NewValue ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
         }
    
         public bool DeliveryStatus
         {
             get { return (bool)GetValue(DeliveryStatusProperty); }
             set
             {
                 SetValue(DeliveryStatusProperty, value);
             }
         }
   }
