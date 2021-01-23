    using Newtonsoft.Json;
    ...
    private User user;
    protected override void OnCreate(Bundle savedInstanceState)
    {
          base.OnCreate(savedInstanceState);
          SetContentView(Resource.Layout.Activity2);
          user = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));
    }
