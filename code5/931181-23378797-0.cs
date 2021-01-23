    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace Log_
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            public ObservableList<LogRecord> LogRecords { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                LogRecords = new ObservableList<LogRecord>();
                DataContext = this;
                new Thread(() =>
                {
                    LogRecord record = new LogRecord();
                    record.Message = "Hello, world.";
                    record.Timestamp = DateTime.Now;
                    List<LogRecord> logRecordList = new List<LogRecord>();
                    for (int i = 0; i < 1000000; i++)
                    {
                        logRecordList.Add(record);
                    }
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    Dispatcher.Invoke(() =>
                    {
                        LogRecords.AddRange(logRecordList);
                    });
                    timer.Stop();
                    Console.WriteLine("The operation took {0} milliseconds.", timer.ElapsedMilliseconds);
                }).Start();
            }
    
            public class LogRecord
            {
                public string Message { get; set; }
                public DateTime Timestamp { get; set; }
            }
    
            public class ObservableList<T> : ObservableCollection<T>
            {
    
                public override event NotifyCollectionChangedEventHandler CollectionChanged;
    
                public void AddRange(IEnumerable<T> list)
                {
                    foreach (var item in list)
                    {
                        Items.Add(item);
                    }
                    OnCollectionChange(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
    
                protected virtual void OnCollectionChange(NotifyCollectionChangedEventArgs e)
                {
                    if (CollectionChanged != null)
                    {
                        CollectionChanged(this, e);
                    }
                }
            }
        }
    }
