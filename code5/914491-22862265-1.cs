    public SelectionDisplay(string itemId, string nextParam="default value")
        {
            this.InitializeComponent();
    
            this.messageTextBlock.Text = string.Format(CultureInfo.CurrentCulture,Properties.Resources.SelectedMessage,itemId);
    
        }
