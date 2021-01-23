    public delegate void SavedEventHandler(/* parameters if you need any information what actually got saved */);
    
    public event SavedEventHandler Saved;
    
    public void OnSaved() {
        var handler = this.Saved;
    
        if (handler != null) {
            handler();
        }
    }
