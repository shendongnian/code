        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            string headerTitle = (string)GetGroup(groupPosition);
            convertView = inflater.Inflate(Resource.Layout.task_child, null);
            TextView header = convertView.FindViewById<TextView>(Resource.Id.label);
            header.Text = headerTitle;
            return convertView;
        }
