    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    
    namespace WpfApplication1
    {
        public class FirstViewModel : ViewModelBase
        {
    
            private string _text;
            public string Text
            {
                get { return _text; }
                set
                {
                    _text = value;
                    RaisePropertyChanged("Text");
                }
            }
    
            public ICommand ChangeToSecondViewCommand
            {
                get
                {
                    return new RelayCommand(() =>
                    {
                        Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = "SecondView" });
                    });
                }
            }
        }
    }
    
