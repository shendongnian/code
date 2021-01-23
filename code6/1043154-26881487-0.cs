    public class MainWindowViewModel : ViewModelBaseClass {
     public ICollectionView accounts { get; private set; }
     private Administrator _admin;
      //ctor
      public MainWindowViewModel()
      {
         _admin = new Administrator();
         this.accounts  = CollectionViewSource.GetDefaultView(this._admin.accounts);
      }
      //subscribe to your model changes and call Refresh
      this.accounts.Refresh();
