    public class ClassBViewModel: INotifyPropertyChanged, IDisposable
    {
        private readonly IDisposable _subscriber;
        public ClassBViewModel(IEventPublisher eventPublisher)
        {
            _subscriber = eventPublisher.Subscribe<ValueChangedEvent>()
                .Subscribe(next => {
                    IsBiggerthanFive = next.Value > 5;
                });
        }
        public void Dispose()
        {
            _subscriber.Dispose();
        }
    }
