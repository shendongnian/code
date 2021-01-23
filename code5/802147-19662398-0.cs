     protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            SetContentView(Resource.Layout.Index);
            Button Contact = FindViewById<Button>(Resource.Id.BtnContact);
            Contact.Click += (sender, e) =>
            {
                StartActivity(new Intent(this, typeof(/* whatever activity you want */ )));
                // e.g.
                //StartActivity(new Intent(this, typeof(SplashActivity)));
            };
    
        }
