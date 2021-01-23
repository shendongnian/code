    public class Startup
    {
        public ViewModel ViewModel { get; set; }
        public View View { get; set; }
        
        public void Startup()
        {
            ViewModel = new ViewModel();
            View = new View();
            
            View.Bind(ViewModel);
            
            View.Show();
            
            ViewModel.IsDoStuffButtonEnabled = true;
            
            // Button becomes enabled on form.
            
            // ... other stuff here.
        }
    }
