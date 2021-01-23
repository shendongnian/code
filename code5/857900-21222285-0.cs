    public override bool OnMenuItemSelected(int featureId, Android.View.IMenuItem item)
    {
        switch (item.GetItemId())
        {
            case Android.R.Id.Home:
                return (true);
            case R.Id.About:
                return (true);
            case R.Id.Help:
                return (true);
        }
        return (base.OnOptionsItemSelected(item));
    }
