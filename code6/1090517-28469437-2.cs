    public override View GetView (int position, View convertView, ViewGroup parent)
    {
        View view;
        if (convertView == null) 
        {  
            view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.my_grid_row, parent, false);
        }
        else
        {
            view = convertView;
        }
        var imageView = view.FindViewById<ImageView>(Resource.Id.my_image_view);
        imageView.SetImageResource (thumbIds[position]);
        
        var textView = view.FindViewById<TextView>(Resource.Id.my_text_view);
        textView.Text = "Text to Display";
        return view;
    }
