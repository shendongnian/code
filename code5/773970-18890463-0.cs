    public Style SelectedStyle
    {
       get { return this.selectedStyle; }
       set { this.selectedStyle = value; 
             RaisePropertyChanged("SelectedStyle");
           }
    }
    private Style selectedStyle;
