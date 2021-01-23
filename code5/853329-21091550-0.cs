    protected override void OnCreate (Bundle bundle)
            {
                base.OnCreate (bundle);
                Intent intent= new Intent(this.ApplicationContext, typeof(AutoLinkActivity));
                intent.SetFlags(ActivityFlags.NewTask);
                StartActivity(intent);
            }
