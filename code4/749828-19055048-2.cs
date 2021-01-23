    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace GridRowHidingSample
    {
        public class MainWindowViewModel : INotifyPropertyChanged
        {
            private RowDefinition _topRow;
            private RowDefinition _bottomRow;
            private bool _isRowVisible = false;
            public MainWindowViewModel(RowDefinition topRow, RowDefinition bottomRow)
            {
                _topRow = topRow;
                _bottomRow = bottomRow;
            }
            private void ResetHeight(RowDefinition rowDefinition)
            {
                if (rowDefinition != null)
                {
                    if (DependencyPropertyHelper.GetValueSource(rowDefinition, RowDefinition.HeightProperty).BaseValueSource == BaseValueSource.Local)
                    rowDefinition.ClearValue(RowDefinition.HeightProperty);
                }
            }
            public bool IsRowVisible
            {
                get { return _isRowVisible; }
                set
                {
                    if (_isRowVisible != value)
                    {
                        _isRowVisible = value;
                        NotifyPropertyChanged("IsRowVisible");
                        if (_isRowVisible)
                            ResetHeight(_topRow);
                        else
                            ResetHeight(_bottomRow);
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void NotifyPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
