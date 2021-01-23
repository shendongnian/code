    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Thingies = new List<Thingy>
                {
                    new Thingy { Name = "abc", IsChecked = false },
                    new Thingy { Name = "def", IsChecked = true },
                    new Thingy { Name = "ghi", IsChecked = false },
                    new Thingy { Name = "jkl", IsChecked = true },
                    new Thingy { Name = "mno", IsChecked = false },
                }.ToArray();
                DataContext = this;
            }
            public Thingy[] Thingies { get; private set; }
            public class Thingy : INotifyPropertyChanged
            {
                public string Name { get; set; }
                public bool IsChecked
                {
                    get
                    {
                        return _isChecked;
                    }
                    set
                    {
                        if (_isChecked != value)
                        {
                            _isChecked = value;
                            if (PropertyChanged != null)
                            {
                                PropertyChanged(this,
                                    new PropertyChangedEventArgs("IsChecked"));
                            }
                            Console.WriteLine(Name + " = " + _isChecked);
                        }
                    }
                }
                bool _isChecked;
                public event PropertyChangedEventHandler PropertyChanged;
            }
        }
    }
