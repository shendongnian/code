    RadioButton radioButton1;
    RadioButton radiobutton2;
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        SetContentView(Resource.Layout.Main);
        radioButton1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
        radioButton2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
        radioButton1.Click += radioButton_Click;
        radioButton2.Click += radioButton_Click;
        //radioButton1 and radioButton2 are recognized here.
    }
    void radioButton_Click(object sender, EventArgs e)
    {
        //radioButton1 and radioButton2 are not recognized here.
        //I want to know how to use IN THIS METHOD the objects loaded from the AXML
        // in OnCreate (the two radio buttons)
    }
