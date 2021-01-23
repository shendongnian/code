    protected override void OnCreate (Bundle bundle)
    {
        base.OnCreate (bundle);
        this.SetContentView (Resource.Layout.Splash);
        ImageView image = FindViewById<ImageView> (Resource.Id.evolticLogo);
        image.SetImageResource (Resource.Drawable.Splash);
        System.Threading.Tasks.Task.Run( () => {
            Thread.Sleep (2000);
            StartActivity (typeof(MainActivity));
        });
    }
