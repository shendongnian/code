    Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
        new Action(delegate()
        {
            this.IconImage.Source = this.newImage;
        }));
