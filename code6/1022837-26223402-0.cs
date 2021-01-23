    public class ParentViewModel : ViewModelBase
    {
        public ParentViewModel()
        {
        }
        public ICommand ShowChildCommand
        {
            get
            {
                return new RelayCommand(()=>this.MessengerInstance.Send<ParentToChildMessage>(new ParentToChildMessage()));
            }
        }
    }
