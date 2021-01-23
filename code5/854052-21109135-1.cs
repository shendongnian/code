    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication1
    {
        public class MainWindowViewModel : ViewModelBase
        {
            private FrameworkElement _contentControlView;
            public FrameworkElement ContentControlView
            {
                get { return _contentControlView; }
                set
                {
                    _contentControlView = value;
                    RaisePropertyChanged("ContentControlView");
                }
            }
    
            public MainWindowViewModel()
            {
                Messenger.Default.Register<SwitchViewMessage>(this, (switchViewMessage) =>
                {
                    SwitchView(switchViewMessage.ViewName);
                });
            }
    
            public ICommand ChangeFirstViewCommand
            {
                get
                {
                    return new RelayCommand(() =>
                    {
                        SwitchView("FirstView");
    
                    });
                }
            }
    
    
            public ICommand ChangeSecondViewCommand
            {
                get
                {
                    return new RelayCommand(() =>
                    {
                        SwitchView("SecondView");
                    });
                }
            }
    
            public void SwitchView(string viewName)
            {
                switch (viewName)
                {
                    case "FirstView":
                        ContentControlView = new FirstView();
                        ContentControlView.DataContext = new FirstViewModel() { Text = "This is the first View" };
                        break;
    
                    default:
                        ContentControlView = new SecondView();
                        ContentControlView.DataContext = new SecondViewModel() { Text = "This is the second View" };
                        break;
                }
            }
        }
    }
