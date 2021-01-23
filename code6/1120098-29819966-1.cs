	public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView ?? inflater.Inflate(Resource.Layout.ImageTextListItem, parent, false);
            var people = peopleList[position];
            var name = view.FindViewById<TextView>(Resource.Id.ListItem_Title);
            var icon = view.FindViewById<ImageView>(Resource.Id.ListItem_Icon);
            name.Text = people.Name;
            icon.SetImageResource(people.Image);
           
            return view;
        }
