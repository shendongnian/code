    public class CustomListViewItem : ListViewItem
    {
        public ImageSource ImageSource { get; set; }
        public string Text { get; set; }
        public CustomListViewItem()
        {
            DataContext = this;
        }
    }
