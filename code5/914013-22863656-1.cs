    public class CustomDataGridControl : DataGridControl
    {
        public CustomDataGridControl()
        {
            var groupLevelDescriptions = (INotifyCollectionChanged)this.GroupLevelDescriptions;
            groupLevelDescriptions.CollectionChanged += collectionChanged_CollectionChanged;
        }
        void collectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            { 
                foreach (var item in e.NewItems)
                {
                    var groupLevelDescription = item as GroupLevelDescription;
                    foreach (var column in this.Columns)
                    {
                        if (column.FieldName == groupLevelDescription.FieldName)
                            column.Visible = false;
                    }
                }
            }
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    var groupLevelDescription = item as GroupLevelDescription;
                    foreach (var column in this.Columns)
                    {
                        if (column.FieldName == groupLevelDescription.FieldName)
                            column.Visible = true;
                    }
                }
            }
        }
    }
