    public class ClassIWroteInViewModel:ViewModelBase{
    
           public RelayCommand TapCommand
           {
                 get;
                 private set;
           }
           public ClassIWroteInViewModel()
           {
                 TapCommand=new RelayCommand(spnl_Tapped);//delegate to spnl_tapped viewmodel method
           }
    
           public ImageSource imgImage { get; set; }
           public string Title { get; set; }      
           
           private async void spnl_Tapped()
          {
                 IReadOnlyList<IStorageItem> PicturesLibrary = await KnownFolders.PicturesLibrary.GetFoldersAsync();                
          }
     }
