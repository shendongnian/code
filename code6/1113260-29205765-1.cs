    public override View GetView (int position, View convertView, ViewGroup parent)
    {
    	var view = convertView;
    
    	if (view == null)
    		view = LayoutInflater.From(context).Inflate(Resource.Layout.SinglePicTile, parent, false);
    	
    	var picture = tile.FindViewById<ImageView>(Resource.Id.PicTile);
    	picture.SetImageURI(Android.Net.Uri.Parse(_imageUrls[position]));
    	return picture;
    }
