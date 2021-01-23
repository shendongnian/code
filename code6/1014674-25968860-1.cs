     public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.MyLayoutId, container, false);
        
            var myListView = view.FindViewById<ListView>(Resource.Id.MyListViewId);
            myListView.ListAdapter = new MyAdapter(Activity, Items);
        }
