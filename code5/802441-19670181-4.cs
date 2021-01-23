    public class MyListView : ListView
    {
        public new MyCollection Columns
        {
            get
            {
                return base.Columns as MyCollection;
            }
            set
            {
                base.Columns = value;
            }
        }
    }
