    public class CustomizableChromeWindow : Window, INotifyPropertyChanged
            {
        
                protected override void OnStateChanged(EventArgs e)
                {
                    base.OnStateChanged(e);
                    OnPropertyChanged("CaptionButtonMargin");
                }
        
                public override void OnApplyTemplate()
                {
                    base.OnApplyTemplate();
                    HandleSizeToContent();
                }
                private void HandleSizeToContent()
                {
                    if (this.SizeToContent == SizeToContent.Manual)
                        return;
        
                    var previosTopXPosition = this.Left;
                    var previosTopYPosition = this.Top;
                    var previosWidth = this.MaxWidth;
                    var previosHeight = this.MaxHeight;
        
                    var previousWindowStartupLocation = this.WindowStartupLocation;
                    var previousSizeToContent = SizeToContent;
                    SizeToContent = SizeToContent.Manual;
                    Dispatcher.BeginInvoke(
                    DispatcherPriority.Loaded,
                    (Action)(() =>
                    {
                        this.SizeToContent = previousSizeToContent;
        
                        this.WindowStartupLocation = WindowStartupLocation.Manual;
        
                        this.Left = previosTopXPosition + (previosWidth - this.ActualWidth)/2;
                        this.Top = previosTopYPosition + (previosHeight - this.ActualHeight) / 2;
                        this.WindowStartupLocation = previousWindowStartupLocation;
                    }));
                }
                public Thickness CaptionButtonMargin
                {
                    get
                    {
                        return new Thickness(0, 0, 0, 0);
                    }
                }
        
                #region INotifyPropertyChanged
                private void OnPropertyChanged(String info)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(info));
                    }
                }
        
                public event PropertyChangedEventHandler PropertyChanged;
                #endregion
            }
