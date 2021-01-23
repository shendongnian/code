    public override bool OnOptionsItemSelected(Android.View.IMenuItem item)
    {
        switch (item.GetItemId())
        {
            case Android.R.Id.Home: // API level 11 and higher (Android 3.0) 
                return (true);
            case R.Id.About:
                return (true);
            case R.Id.Help:
                return (true);
        }
        return (base.OnOptionsItemSelected(item));
    }
