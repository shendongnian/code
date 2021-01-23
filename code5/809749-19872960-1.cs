    public class ViewModel : INotifyPropertyChanged
    {
       ObservableCollection<UserDetail> items = new ObservableCollection<UserDetail>();
       .....
       .....
       public ViewModel(User u)
       {
         UserDetail ud = new UserDetail(u);
         //assign your data to this view class here and finally add it to the collection
         .....
         .....
         
         items.Add(ud);
       }
    }
