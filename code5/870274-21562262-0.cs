    public class AlbumViewModel: BaseViewModel // BaseViewModel is your code that implements INotifyPropertyChanged
    {
    private string name
    public string Name
    {
       get{ return name;}
       set
       {
          if(name != value)
          {
              name = value;
              FirePropertyChanged("Name");
              LoadBackgroundImageAsync(value);
          }
       }
    }
    private ImageSource backgroundImage;
    public ImageSource BackgroundImage
    {
         get{return backgroundImage;}
         private set
         {
           if(backgroundImage != value)
           {
               background = value;
               FirePropertyChanged("BackgroundImage");
           }
         }
    }
    private Task LoadBackgroundImageAsync(string name)
    {
        var retv = new Task(()=>
        {
            var source = GlobalDB.GetImage(name, 400);
            source.Freeze();
            BackgroundImage = source;
        });
        retv.Start();
        return retv;
    }
    }
