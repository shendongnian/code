    public class ViewModel {
       private ObservableCollection<ChainCode> _chainCode = new ObservableCollection<ChainCode>();
        
       public ObservableCollection<ChainCode> OCChainCode 
       { 
           // No need for a public setter
           get { return _chainCode; }        
       }
    }
