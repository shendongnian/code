    public string SelectedStyle
    {
       get { return this.selectedStyle; }
       set { this.selectedStyle = value; 
             RaisePropertyChanged("SelectedStyle");
           }
    }
    private string selectedStyle;
    
