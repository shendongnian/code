    public override View GetView(int position, View convertView, ViewGroup parent)
            {
                CustomerHolder holder = null;
                var view = convertView;
    
                if (view == null)
                {
                    view = Context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);
    
                    holder = new CustomerHolder();
                    holder.Name = view.FindViewById<TextView>(Resource.Id.textViewName);
                    holder.Email = view.FindViewById<TextView>(Resource.Id.textViewEmail);
                    holder.Phone = view.FindViewById<TextView>(Resource.Id.textViewPhone);
                    holder.Image = view.FindViewById<ImageButton>(Resource.Id.imageViewThumbail);
                    
                    view.Tag = holder;
                }
                else
                {
                        holder = view.Tag as CustomerHolder;
                }
    
                //At this point the holder holds reference to your view objects, whether they are 
                //recycled or created new. 
                //Next then you need to populate the views with the Customer info
    
                var Customer = Customers[position];
                holder.Name.Text = Customer.Name;
                holder.Email.Text = CustomerHolder.Email;
                holder.Phone.Text = Customer.Phone;
                holder.Image.SetImageResource = (Resource.Drawable.defaulthumbnail);
                holder.Image.Clickable = true;
                holder.Image.Click += (o, e) =>
                {
                       var myActivity = (MainActivity)Context;
                       myActivity.OnThumbnailclicked((Customer[position).id);
                    
                };
                return view;
            }
    
           private class CustomerHolder : Java.Lang.Object
            {
                public TextView Name { get; set; }
                public TextView Email { get; set; }
                public TextView Phone { get; set; }
                public ImageView Thumbnail { get; set; }                
            }        
        
    }
