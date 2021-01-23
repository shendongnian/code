    public sealed partial class FirstRunPage : VisualStateAwarePage
    {
        public FirstRunPage()
        {
           // ...
           InitializeComponent();
           HardwareButtons.BackPressed += HardwareButtons_BackPressed;   
           HardwareButtons.BackPressed += HardwareButtons_BackPressed; 
        }
        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            bool isHandled = false;
            Action handledCallback = () => isHandled = true;
            var state = new Dictionary<string, object> { { "Callback", handledCallback } };
            ((INavigationAware)this.DataContext).OnNavigatedTo("Back", NavigationMode.Back, state);
            args.Handled = isHandled;
        };
    }
