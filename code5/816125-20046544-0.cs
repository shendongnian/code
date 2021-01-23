    var button = FindViewById<Button>(Resource.Id.MyButton);
    var et1 = FindViewById<EditText>(Resource.Id.editText1);
    var et2 = FindViewById<EditText>(Resource.Id.editText2);
    var et3 = FindViewById<EditText>(Resource.Id.editText3);
    button.Click += (s,e) =>
    {
        var text1 = et1.Text;
        var text2 = et2.Text;
        var text3 = et3.Text;
        Toast.MakeText(this, string.Format("T1: {0}, T2: {1}, T3: {2}", text1, text2, text3), ToastLength.Short).Show();
    };
