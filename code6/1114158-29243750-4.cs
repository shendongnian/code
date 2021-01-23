    using GalaSoft.MvvmLight.Command;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace WpfApplication1
    {
        public class CustomControl1 : TextBox
        {
            public CustomControl1()
                : base()
            {
                MyCommand = new RelayCommand(() => Execute(), () => CanExecute());
            }
    
            static CustomControl1()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
            }
    
            public static DependencyProperty MyCommandProperty = DependencyProperty.Register("MyCommand", typeof(ICommand), typeof(CustomControl1));
            public ICommand MyCommand
            {
                get { return (ICommand)GetValue(MyCommandProperty); }
                private set { SetValue(MyCommandProperty, value); }
            }
    
            private void Execute()
            {
                //Do stuff
            }
    
            private bool CanExecute()
            {
                return true;
            }
        }
    }
