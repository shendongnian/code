    public override Java.Lang.Object InstantiateItem (View collection, int position)
    {
        ImageView i = new ImageView (context);
        //i.LayoutParameters = new Gallery.LayoutParams (150, 100);
        i.SetScaleType (ImageView.ScaleType.FitCenter);
        Picasso.With (context).Load (mitems [position]).Into (i);
        var viewPager = collection.JavaCast<ViewPager>();
        viewpager.AddView (i);
        return i;
    }
