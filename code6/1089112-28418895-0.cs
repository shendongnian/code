    class View : UserControl, IAppender{
        View(){
           InitializeComponent();
           DataContext = new YourViewModel(this);
        }
        void Append(string appendText){
            //add text to richttext
        }
    }
    public class YourViewModel : ViewModelBase{
       private IAppender _appender;
       public YourViewModel(IAppender appender){
           _appender = appender;
       }
    }
