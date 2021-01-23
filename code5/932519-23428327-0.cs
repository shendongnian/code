    public ICommand SearchCommand
            {
                get
                {
                    return (ICommand)this.Dispatcher.Invoke(
                           System.Windows.Threading.DispatcherPriority.Background,
                           (DispatcherOperationCallback)delegate { return this.GetValue(SearchCommandProperty); },
                           SearchCommandProperty);
                   // Instead of this
                   // return this.GetValue(SearchCommandProperty);
                }
                set
                {
                    this.SetValue(SearchCommandProperty, value);
                }
            }
