    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;
    namespace TestSO.model
    {
        public class Cell : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void RaisePropertyChanged(string propertyName)
            {
                var local = PropertyChanged;
                if (local != null)
                {
                    Application.Current.Dispatcher.BeginInvoke(local, this, new PropertyChangedEventArgs(propertyName));
                }
            }
            private int x;
            public int X
            {
                get
                {
                    return x;
                }
                set
                {
                    if (x == value)
                    {
                        return;
                    }
                    x = value;
                    RaisePropertyChanged("X");
                }
            }
            private int y;
            public int Y
            {
                get
                {
                    return y;
                }
                set
                {
                    if (y == value)
                    {
                        return;
                    }
                    y = value;
                    RaisePropertyChanged("Y");
                }
            }
            private bool isWall;
            public bool IsWall
            {
                get
                {
                    return isWall;
                }
                set
                {
                    if (isWall == value)
                    {
                        return;
                    }
                    isWall = value;
                    RaisePropertyChanged("IsWall");
                }
            }
            private SolidColorBrush _cellColor;
            public SolidColorBrush CellColor
            {
                get
                {
                    // either return the _cellColor, or say that it is transparent
                    return _cellColor ?? Brushes.Transparent;
                }
                set
                {
                    if (SolidColorBrush.Equals(_cellColor, value))
                    {
                        return;
                    }
                    _cellColor = value;
                    RaisePropertyChanged("CellColor");
                }
            }
            public Cell()
            {
            }
            public Cell(int x, int y)
                : this()
            {
                this.X = x;
                this.Y = y;
            }
        }
    }
