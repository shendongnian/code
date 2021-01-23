    public class BaseViewModel : INotifyPropertyChanged
    {
     
        public abstract bool IsBusy { get; }
    
    }
    
    public class FancyViewModel : BaseViewModel
    {
    
        public override bool IsBusy
        {
            get { return [check #1] && [check #2]...; }
        }
    }
