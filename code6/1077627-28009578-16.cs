    // This would be plain C# class in WP8, too
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    namespace WpfApplication1
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            // This event takes care of notifying the page so it updates
            public event PropertyChangedEventHandler PropertyChanged;
            private string _countDown;
            public MainViewModel()
            {
                // Day to countdown to
                DateTime targetDate = DateTime.Now.AddDays(5d);
                
                // Start new thread
                Task.Factory.StartNew(() =>
                    {
                        // Loop until target date and update value every second
                        while (DateTime.Now <= targetDate)
                        {
                            // Format and set new value
                            CountDown = (targetDate - DateTime.Now).ToString("d'd 'h'h 'm'm 's's'");
                            Thread.Sleep(1000);
                        }
                        // Final value
                        CountDown = "It's tiem!";
                    });
            }
            // Value displayed in Page's TextBlock
            public string CountDown
            {
                get { return _countDown; }
                set { _countDown = value; OnPropertyChanged();}
            }
            // This is INotifyPropertyChanged implementation
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) 
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
