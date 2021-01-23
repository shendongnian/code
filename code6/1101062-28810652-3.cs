    public class MyViewModel : ViewModel 
    {
        private Rect selection;
        public Rect Selection 
        {
            get 
            {
                return selection;
            }
            set 
            {
                selection = value;
                
                // Or whatever the name of your framework/implementation the method is called
                OnPropertyChanged("Selection");
                // Cause ICommands to reevaluate their CanExecute methods
                CommandManager.InvalidateRequerySuggested(); 
            }
        }
        
        private ICommand cropCommand;
        public ICommand CropCommand {
            get 
            {
                if(cropCommand==null)
                    cropCommand = new RelayCommand(Crop, () => Selection.Width > 0); // only allow execution when Selection width > 0
                return cropCommand;
            }
        }
        
        public void Crop() 
        {
            // Get a copy of the selection in case it changes during execution
            Rect cropSelection = Selection; 
            
            // use it to crop your image
            ... 
        }
    }
