    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;
    
    namespace ComboBoxDemo
    {
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private ICommand addItemCommand;
            private ICommand comboBoxItemAddCommand;
            private ObservableCollection<Parameter> parameters;
    
            public MainWindow()
            {
                InitializeComponent();
                Parameters = new ObservableCollection<Parameter>();
                AddItemCommand = new RelayCommand(AddItem);
                ComboBoxItemAddCommand = new RelayCommand(ComboBoxItemAdd);
            }
    
            private void ComboBoxItemAdd(object parameter)
            {
                Parameter para = parameter as Parameter;
                if (para != null)
                {
                    // Now you can use your Parameter
                }
            }
    
            public ObservableCollection<Parameter> Parameters
            {
                get { return parameters; }
                set
                {
                    parameters = value;
                    OnPropertyChanged();
                }
            }
    
            public ICommand AddItemCommand
            {
                get { return addItemCommand; }
                set
                {
                    addItemCommand = value;
                    OnPropertyChanged();
                }
            }
    
            public ICommand ComboBoxItemAddCommand
            {
                get { return comboBoxItemAddCommand; }
                set
                {
                    comboBoxItemAddCommand = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void AddItem(object parameter)
            {
                Parameters.Add(new Parameter
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Any Name"
                });
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
