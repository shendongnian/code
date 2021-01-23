    public class SelectionDisplay
    {
        public SelectionDisplay(string itemId, string Tag)
        {
            this.InitializeComponent();
    
            this.messageTextBlock.Text = string.Format(CultureInfo.CurrentCulture,Properties.Resources.SelectedMessage,itemId);
    
        }
        public SelectionDisplay(object label, Brush background)
        {
            //Do stuff
        }
    }
