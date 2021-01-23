    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace SO18779291
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.setNewContext.Click += (s, e) => this.DataContext = new MyViewModel();
                this.DataContext = new MyViewModel();
            }
        }
    
        public class MyCustomControl : Control
        {
            public static readonly DependencyProperty TxtProperty =
                DependencyProperty.Register("Txt", typeof(string), typeof(MyCustomControl), new UIPropertyMetadata(OnTxtChanged));
    
            static MyCustomControl()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));
            }
    
            public MyCustomControl()
            {
                this.DataContextChanged += (s, e) =>
                {
                    this.Dispatcher.BeginInvoke((Action)delegate
                    {
                        this.SetCurrentValue(TxtProperty, "123");
                    });
                };
            }
    
            public string Txt
            {
                get { return (string)this.GetValue(TxtProperty); }
    
                set { this.SetValue(TxtProperty, value); }
            }
    
            private static void OnTxtChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
            {
                Console.WriteLine("Changed: '{0}' -> '{1}'", e.OldValue, e.NewValue);
            }
        }
    
        public class MyViewModel : INotifyPropertyChanged
        {
            private string str;
    
            public string Str
            {
                get { return this.str; }
                set
                {
                    if (this.str != value)
                    {
                        this.str = value; this.OnPropertyChanged("Str");
                    }
                }
            }
    
            protected void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null && propertyName != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
