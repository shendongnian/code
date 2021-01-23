    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            TabHost tabHost = FindViewById(Resource.Id.tabhost_sample) as TabHost;
            tabHost.Setup();
            TabHost.TabSpec tabSpec1 = tabHost.NewTabSpec("SampleTab1");
            tabSpec1.SetContent(Resource.Id.tab_sampletab1);
            tabSpec1.SetIndicator("SampleTab1");
            TabHost.TabSpec tabSpec2 = tabHost.NewTabSpec("SampleTab2");
            tabSpec2.SetContent(Resource.Id.tab_sampletab2);
            tabSpec2.SetIndicator("SampleTab2");
            tabHost.AddTab(tabSpec1);
            tabHost.AddTab(tabSpec2);
        }
    }
