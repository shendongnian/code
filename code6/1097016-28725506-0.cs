    //need to reference Drawables otherwise StateListDrawable is not recognized.
    using Android.Graphics.Drawables;
    
    //...
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           //...
           mySwitch = view.FindViewById<Switch>(Resource.Id.theSwitchIdFromXml);
           //... 
            Android.Graphics.Color colorOn = Android.Graphics.Color.Green;
            Android.Graphics.Color colorOff = Android.Graphics.Color.Brown;
            Android.Graphics.Color colorDisabled = Android.Graphics.Color.Gray;
            StateListDrawable drawable = new StateListDrawable();
            drawable.AddState(new int[] { Android.Resource.Attribute.StateChecked }, new ColorDrawable(colorOn));
            drawable.AddState(new int[] { -Android.Resource.Attribute.StateEnabled }, new ColorDrawable(colorDisabled));
            drawable.AddState(new int[] { }, new ColorDrawable(colorOff));
            mySwitch.ThumbDrawable = drawable;
      }
