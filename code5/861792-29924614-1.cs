    public partial class ModernWindow1 : ModernWindow 
        {
            
            public ModernWindow1()
            {
                InitializeComponent();
                
    
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
    			/*
    			this will show the second modernwindow using the second constructor with parameter
    			*/
                ModernWindow2 newWindow2 = new ModernWindow2(this);  
                newWindow2.Show();
            }
        }
    	
	
