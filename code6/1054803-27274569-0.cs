    using System;
    using System.ComponentModel;
    using System.Reactive.Linq;
    
    namespace MyNameSpace
    {
        public class NotifyPropertyChangeClass : INotifyPropertyChanged
        {
            private bool _isThrottling = false;
    
            public NotifyPropertyChangeClass(int throttlingPeriod)
            {
                var obs = Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                   h => this.privatePropertyChanged += h, h => this.privatePropertyChanged -= h);
                var groupedByName = obs.Select(o => o.EventArgs.PropertyName).GroupBy(x => x).SelectMany(o => o.Sample(TimeSpan.FromMilliseconds(throttlingPeriod)));
                groupedByName.Subscribe(o =>
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                        handler(this, new PropertyChangedEventArgs(o));
                    _isThrottling = false;
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private event PropertyChangedEventHandler privatePropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                // Will fire the first time, the event is raised
                if (!_isThrottling)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                        handler(this, new PropertyChangedEventArgs(o));
                }
    
                // Setting to true here will suppress raising the public event 
                // for every subsequent call, until the event is raised
                // by the observable pattern and the flag is set to false again.
                _isThrottling = true;
    
                // Will always be raised
                PropertyChangedEventHandler handler = privatePropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
