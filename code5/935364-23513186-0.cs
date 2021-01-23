     public class MainViewSurroundingModel : INotifyPropertyChanged
     {
          //...omitted the parts you have done, only writing the things I'd change...
          MainViewSurroundingModel()
          {
               ..if there was something leave it here..
               changeTimer = new DispatcherTimer...
               changeTimer.Tick += Tick;
               changeTimer.Interval = ....et cetera, setting the timer based on tutorial
          }
          public ObservableCollection<LocationsModel> items;
          public ObservableCollection<LocationsModel> Items 
          {
            get //edited so that I can write my own setter
            {
                return items;
            }
            set
            {
                if(value != items)
                {
                   items = value;
                   //NotifyPropertyChanged("Items"); //can be used here, not necessary
                   changeTimer.Start();
                }
            }
          }
          private DispatcherTimer changeTimer;//based on the tutorial
          //based on the tutorial provided, create dispatcher timer and
          //tick definition somewhere around here
          private Tick(...)
          {
              //code that iterates through the list and updates it goes here!
          }
          
     }
