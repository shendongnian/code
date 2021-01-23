    public class SongListAdapter : BaseAdapter<Song> {
        private List<Song> _items;
        private Activity _context;
        public SongListAdapter(Activity context, List<Song> songs)
        {
            this._items = songs;
            this._context = context;
        }
        
        public override Song this[int position]
        {
            get { return this._items[position]; }
        }
        public override int Count
        {
            get { return this._items.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this._items[position];
            View view = convertView;
            //If there is nothing to reuse, then create view from your row layout
            if (view == null)
                view = this._context.LayoutInflater.Inflate(Resource.Layout.SongListRow, null); 
            view.FindViewById<TextView>(Resource.Id.SongTitle).Text = item.Name; 
            return view;
        }
    }
