    public partial class MyWindow : Window
    {
        /* Window c'tor, other methods/props ommited */
        
        // Load our custom controls asynchronously after the window is rendered
        private async void MyWindow_ContentRendered(object sender, EventArgs e)
        {
            // kick off the asynchronous call to create a custom controls
            await CreateCustomControls();
        }
        
        // Asynchronously adds MyCustomControls to the ObservableCollection 
        // (we actually used a separate static class that contained our definitions
        // and created the controls) 
        private async Task CreateCustomControls()
        {
            // the def describes what you want to build and is not detailed here
            foreach (var controlDef in MyCustomControlDefinitions)
            {
                // create a control based on the definition
                var newControl = await CreateMyCustomControl(controlDef);
                // Don't add the control until it is completely built
                MyCustomControls.Add(newControl);
            }
        }
        
        //The (bindable) collection of custom controls
        public ObservableCollection<MyCustomControl> MyCustomControls
        {
            get { return (ObservableCollection<MyCustomControl>)GetValue(MyCustomControlsProperty); }
            set { SetValue(MyCustomControlsProperty, value); }
        }
        
        public static readonly DependencyProperty MyCustomControlsProperty =
        DependencyProperty.Register("MyCustomControls", typeof(ObservableCollection<MyCustomControl>),
            typeof(MyWindow), new PropertyMetadata(new ObservableCollection<MyCustomControl>()));
        
    }
