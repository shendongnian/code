    [Activity (Label = "Increment", MainLauncher = true)]
    public class MainActivity : Activity, View.IOnClickListener
    {
        private readonly int[] array = new int[4];
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate (bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            // Get our button from the layout resource,
            // and attach an event to it
            Button cola = FindViewById<Button> (Resource.Id.myButton);
		
            // will happen first (in order of assigned)
            cola.Click += delegate
            {
                array [0]++;
            };
            // second
            cola.Click += (sender, e) => array[1]++;
            // third
            cola.Click += HandleClick;
            // if uncommented this will remove other events
            //cola.SetOnClickListener (this);
        }
        void HandleClick (object sender, EventArgs e)
        {
            array [2]++;
        }
        public void OnClick(View v)
        {
            array [3]++;
        }
    }
