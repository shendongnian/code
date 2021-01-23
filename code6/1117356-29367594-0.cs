    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace longlistselector
    {
        class GroupClass : INotifyPropertyChanged
        {
    
    
            public string ImageSource
            {
                get;
                set;
            }
    
            public string Content
            {
                get;
                set;
            }
            public string Name
            {
                get;
                set;
            }
            public long UnitGroupID
            {
                get;
                set;
            }
            private bool isActive;
            public bool IsActive
            {
                get { return isActive; }
                set
                {
                    isActive = value;
                    Content = isActive ? "/Assets/Images/Active.png" : "/Assets/Images/Inactive.png";
                    OnPropertyChanged("IsActive");
                    OnPropertyChanged("Content");
    
                }
    
            }
    
            public bool IsCustom
            {
                get;
                set;
            }
            public bool IsChecked
            {
                get;
                set;
            }
            private bool isEditable;
            public bool IsEditable
            {
                get { return isEditable; }
                set
                {
                    if (value != isEditable)
                    {
                        isEditable = value;
    
                        OnPropertyChanged("IsEditable");
                        ControlVisibility = isEditable ? Visibility.Visible : Visibility.Collapsed;
                        OnPropertyChanged("ControlVisibility");
                    }
                }
    
            }
            public Visibility IsCustomControlVisibility
            {
                get { return IsEditable & IsCustom ? Visibility.Visible : Visibility.Collapsed; }
            }
            public Visibility ControlVisibility
            {
                get;
                set;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
