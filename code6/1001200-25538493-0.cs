    Class YourClassName {
    private RadioButton raduiButton1;
    private RadioButton raduiButton2;
    .
    .
    .
      protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        SetContentView(Resource.Layout.Main);
        radioButton1 = (RadioButton) FindViewById<RadioButton>(Resource.Id.radioButton1);
        radioButton2 = (RadioButton) FindViewById<RadioButton>(Resource.Id.radioButton2);
        radioButton1.Click += radioButton_Click;
        radioButton2.Click += radioButton_Click;
        //radioButton1 and radioButton2 are recognized here.
    }
    rest of code...
}
