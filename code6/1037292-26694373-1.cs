    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    namespace WPFThreadDemo
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                // Create a new model and set the data context to point at it
                Model model = new Model();
                this.DataContext = model;
    
                // Set up a new worker to do some work on another thread and update the mode
                Worker worker = new Worker(model);
                worker.DoWork(100);
            }
        }
    
    
        public class Model : INotifyPropertyChanged
        {
    
            // Implementation of INotifyPropertyChanged
            // The progress bar will be hooked up to this event by the binding
            // When the event is raised with a name used in a binding, the model is queried
            // for the new value and the display is updated
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void RaisePropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    var eventArgs = new PropertyChangedEventArgs(propertyName);
                    handler(this, eventArgs);
                }
            }
    
            // Store for the channel values
            Dictionary<int, int> _channels = new Dictionary<int, int>();
    
            // Simple wrapper around the dictionary which creates a default value of 0 if it doesn't exist yet
            private int GetValue(int channel)
            {
                if (!_channels.ContainsKey(channel))
                {
                    _channels[channel] = 0;
                }
    
                return _channels[channel];
    
            }
    
            // If the value is new or has changed, store it and raise property changed notification to update display
            public void SetValue(int channel, int value)
            {
                int oldValue;
                bool valueExists = _channels.TryGetValue(channel, out oldValue);
    
                // nothing to do if the value already exists and it hasn't changed
                if (valueExists && oldValue == value) return;
    
                _channels[channel] = value;
                RaisePropertyChanged("Channel" + channel.ToString());
            }
    
    
            // WPF binding works against public properties so we need to provide properties to bind against
    
            public int Channel1
            {
                get
                {
                    return GetValue(1);
                }
                set
                {
                    SetValue(1, value);
                }
            }
    
            public int Channel2
            {
                get
                {
                    return GetValue(2);
                }
                set
                {
                    SetValue(2, value);
                }
            }
        }
    
        // Simple worker mock which updates the model values on another thread
        public class Worker
        {
            Model _valueStore;
    
            public Worker(Model valueStore)
            {
                _valueStore = valueStore;
            }
    
            public void DoWork(int duration)
            {
                ThreadPool.QueueUserWorkItem(
                    (x) =>
                    {
                        for (int channel = 0; channel < 2; channel++)
                        {
                            for (int value = 0; value < 100; value++)
                            {
                                _valueStore.SetValue(channel + 1, value + 1);
                                Thread.Sleep(duration);
                            }
                        }
                    });
            }
        }
    }
