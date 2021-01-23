    public class ExampleAdapter : BaseAdapter
    {
        private const int ItemViewTypeListItem = 0;
        private const int ItemViewTypeSeparator = 1;
        private const int ItemViewTypeCount = 2;
        private readonly Activity _context;
        private readonly List<object> _spartendaten;
        public SparendatenAdapter(Activity context, List<object> items)
        {
            _context = context;
            _spartendaten = items;
        }
        public override Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override int ViewTypeCount
        {
            get
            {
                return ItemViewTypeCount;
            }
        }
        public override int GetItemViewType(int position)
        {
            return _spartendaten[position] is Separator
                ? ItemViewTypeSeparator
                : ItemViewTypeSpartendaten;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //
        }
        public override int Count
        {
            get { return _spartendaten.Count; }
        }
        private class ViewHolder : Object
        {
            private TextView _tvTitle;
			//... separator and list item declarations
            public void Bind(Activity context, int position, object item, int itemType)
            {
                if (itemType == ItemViewTypeSeparator)
                {
                    //bind your separatorview
                }
                else
                {
                    //bind your 
                }
                
            }
            public void Initialize(View view, int itemType)
            {
                if (itemType == ItemViewTypeListItem)
                {
                    //initialize list item
                }
                else
                {
                    //initialize separator
                }
                
            }
        }
    }
