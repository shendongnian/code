    public class ComboBox : System.Windows.Controls.ComboBox
    {
        private bool ignore = false;
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            if (!ignore)
            {
                base.OnSelectionChanged(e);
            }
        }
        
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            ignore = true;
            try
            {
                base.OnItemsChanged(e);
            }
            finally
            {
                ignore = false;
            }
        }
    }
