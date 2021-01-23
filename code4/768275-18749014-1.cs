    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication1
    {
        public partial class Test : UserControl, INotifyPropertyChanged
        {
            public Test()
            {
                InitializeComponent();
            }
    
            private string _text = "orignal text";
            public string Text
            {
                get { return _text; }
                set
                {
                    _text = value;
                    NotifyOfPropertyChange("Text");
                }
            }
       
            public Action<Test> TestAction
            {
                get { return (Action<Test>)GetValue(TestActionProperty); }
                set { SetValue(TestActionProperty, value); }
            }
            public static readonly DependencyProperty TestActionProperty = DependencyProperty.Register("TestAction", typeof(Action<Test>), typeof(Test), null);
    
            private void GoClick(object sender, RoutedEventArgs e)
            {
                if (TestAction != null)
                    TestAction(this);
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyOfPropertyChange(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
