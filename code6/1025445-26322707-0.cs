    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    
    namespace TestingApp.ViewModel
    {
        /// <summary>
        /// This class contains properties that the main View can data bind to.
        /// <para>
        /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
        /// </para>
        /// <para>
        /// You can also use Blend to data bind with the tool's support.
        /// </para>
        /// <para>
        /// See http://www.galasoft.ch/mvvm
        /// </para>
        /// </summary>
        public class MainViewModel : ViewModelBase
        {
            private Int32 _increment = 0;
    
            public Int32 Increment
            {
                get { return _increment; }
                set
                {
                    _increment = value;
                    RaisePropertyChanged("Increment");
                    GoCommand.RaiseCanExecuteChanged();
                }
            }
    
            /// <summary>
            /// Initializes a new instance of the MainViewModel class.
            /// </summary>
            public MainViewModel()
            {
                ////if (IsInDesignMode)
                ////{
                ////    // Code runs in Blend --> create design time data.
                ////}
                ////else
                ////{
                ////    // Code runs "for real"
                ////}
            }
    
            private RelayCommand _incrementCommand;
    
            public RelayCommand IncrementCommand
            {
                get
                {
                    if (_incrementCommand == null)
                    {
                        _incrementCommand = new RelayCommand(IncrementCommand_Execute);
                    }
                    return _incrementCommand;
                }
            }
    
            private void IncrementCommand_Execute()
            {
                Increment++;
            }
    
            private RelayCommand _goCommand;
    
            public RelayCommand GoCommand
            {
                get
                {
                    if (_goCommand == null)
                    {
                        _goCommand = new RelayCommand(GoCommand_Execute, GoCommand_CanExecute);
                    }
                    return _goCommand;
                }
            }
    
            private bool GoCommand_CanExecute()
            {
                return Increment > 5;
            }
    
            private void GoCommand_Execute()
            {
                //
            }
        }
    }
