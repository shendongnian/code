    public Page myFirstPage = null;
    
    public partial class FirstPage : Page
      {
         FirstPage()
          {
               initializeComponent(); 
          } 
         
         void onLoadedEvent(Object Sender, Eventargs e)
         {
            myFirstPage = this;
         }
      }
