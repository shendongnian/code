    public class FirstViewModel : INotifyPropertyChanged
    {
       private IMesseger messenger;
    
       ...
    
       public FirstViewModel(IMessenger messenger)
       {
           this.messenger = messenger;
       }
    
       public Item SelectedItem
       {
           get
           {
                return this.selectedItem;
           }
    
           set
           {
                this.selectedItem = value;
                this.messenger.Send(new GenericMessage<Item>(this.selectedItem));
                this.OnPropertyChanged("SelectedItem");
           }
       }
    }
    
    public class SecondViewModel : INotifyPropertyChanged
    {
       private IMesseger messenger;
    
       ...
       
       public SecondViewModel(IMessenger messenger)
       {
           this.messenger = messeger;
           this.messenger.Register<GenericMessage<Item>>(this, this.HandleItemSelected);
       }
       
       ...
    }
