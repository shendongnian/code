    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    namespace WpfApplication1
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private string _countDown;
            public MainViewModel()
            {
                DateTime targetDate = DateTime.Now.AddDays(5d);
                
                Task.Factory.StartNew(() =>
                    {
                        while (DateTime.Now <= targetDate)
                        {
                            CountDown = (targetDate - DateTime.Now).ToString("d'd 'h'h 'm'm 's's'");
                            Thread.Sleep(1000);
                        }
                        CountDown = "It's tiem!";
                    });
            }
            public string CountDown
            {
                get { return _countDown; }
                set { _countDown = value; OnPropertyChanged();}
            }
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) 
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
