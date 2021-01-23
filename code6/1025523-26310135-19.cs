    public class EncryptorViewModel1 : ViewModelBase
    {
        //private EncryptorModel Model { get; set; }
        
        public EncryptorViewMode1l()
        {
            // Model = new EncryptorModel();
            // Now you retrieve the model in App.xaml instead of declaring a private one above
            var model =(EncryptorModel) Application.Current.FindResource("Model1");
        }
    }
