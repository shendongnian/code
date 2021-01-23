    public SelectionDisplay(string itemId)
        {
            this.InitializeComponent();
    
            this.messageTextBlock.Text = string.Format(CultureInfo.CurrentCulture,Properties.Resources.SelectedMessage,itemId);
    
        }
