    public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        // Perform the IsDirty check so we don't get stuck in a infinite loop.
        if (propertyName != "IsDirty")
        {
            this.IsDirty = true; // Each time a property value is changed, we set the dirty bool.
        }
        if (this.PropertyChanged != null)
        {
            // Invoke the event handlers attached by other objects.
            try
            {
                // When unit testing, this will always be null.
                if (Application.Current != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
                }
                else
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
