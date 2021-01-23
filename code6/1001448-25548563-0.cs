    public class MyStopDetailsViewModel : ViewModelBase
    {
        public MyStopDetailsViewModel(Stop myStop, IMessageService messageService, IPleaseWaitService pleaseWaitService)
        {
             // Here is the context with the injected Stop parameter. Note that I have
             // also injected several other services to show how you can use the combination
        }
    }
