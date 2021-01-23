    public partial class ModernWindow2 : ModernWindow
        {
            public dynamic ReferencedWindow2; //you will put the original Window here
    
            public ModernWindow2()
            {
                InitializeComponent();
            }
    
            public ModernWindow2(dynamic referencedWindow) // second constructor with a parameter
            {
                InitializeComponent();
                ReferencedWindow2 = referencedWindow; // the original modernwindow being put in here
            }
    
            private void Button_OnClick(object sender, RoutedEventArgs e)
            {
                ReferencedWindow2.Close();
            }
        }
	
	
