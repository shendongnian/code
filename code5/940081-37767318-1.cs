    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using myProject.View;
    using myProject.Models;
    namespace myProject.ViewModel
    {
        public class MainViewModel : ObservableObject
        {
            public MainViewModel() { }
            // This handles adding framework (UI) elements to the main window frame
            ObservableCollection<FrameworkElement> _MainWindowFrameContent = new ObservableCollection<FrameworkElement>();
            public ObservableCollection<FrameworkElement> MainWindowFrameContent
            {
                get { return _MainWindowFrameContent; }
                set { _MainWindowFrameContent = value; RaisePropertyChangedEvent("MainWindowFrameContent"); }
            }
        }
    }
