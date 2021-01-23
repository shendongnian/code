    public partial class WMIView : UserControl
    {
         public WMIView()
         { 
             InitializeComponent();
            this.datacontext = new WMIViewModel(); 
            
         }
    }
