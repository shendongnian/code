    public override View GetView(int position, View convertView, ViewGroup parent)
        {
            MenuItemHolder holder = null;
            var view = convertView;
            YourItemClass item = GetItem(position);
            if (view != null)
            {
                holder = view.Tag as MenuItemHolder;
            }
            if (holder == null)
            {
                holder = new MenuItemHolder();
                view = LayoutInflater.From(Context).Inflate(Resource.Layout.rowWithButtons, null);
                holder.RemoveButton = view.FindViewById<Button>(Resource.Id.DecreaseButton);
                holder.AddButton = view.FindViewById<Button>(Resource.Id.IncreaseButton);
                holder.NumberTextView = view.FindViewById<TextView>(Resource.Id.NumberTextView);
                holder.AddButton.Click += delegate
                {                        
                    item.Value++
                    holder.NumberTextView.Text = (item.Value).ToString();
                };
                holder.RemoveButton.Click += delegate
                {
                    if (item.Value > 1))
                    {
                        item.Value--;
                        holder.NumberTextView.Text = (item.Value).ToString();
                    }
                };
                view.Tag = holder;
            }
            holder.Title.Text = GetItem(position).Name;
            holder.NumberTextView.Text = (item.Value).ToString();
            return view;
        }
