    public static class NavigationBridge
    {
        public static Action<object> FinishedNavigating { get; set; }
    }
    public class Activity1
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            someButton.Click += (sender, args) => 
            {
                NavigationBridge.FinishedNavigating = activity2 =>
                {
                    Activity2 activity = (Activity2)activity2;
                    // Vuola, you now have a reference to the instance.
                    // Use this reference to set public properties in Activity2, 
                    // using data from *this* Activity1
                };
                var intent = new Intent(this, typeof(Activity2));
                this.StartActivity(intent);
            };
        }
    }
    public class Activity2
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            if (NavigationBridge.FinishedNavigating != null)
            {
                NavigationBridge.FinishedNavigating(this);
                NavigationBridge.FinishedNavigating = null;
            }
        }
    }
