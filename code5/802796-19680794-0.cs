               LinearLayout ly = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
             Bla WebS = new Bla();
             foreach (var item in WebS.Fetch(null, null, null))
             {
                 var Params = new Android.Widget.LinearLayout.LayoutParams(Android.Widget.LinearLayout.LayoutParams.MatchParent, Android.Widget.LinearLayout.LayoutParams.WrapContent);
                 Button b = new Button(this);
                 b.Text = item.Naam;
                 b.Id = Convert.ToInt16(item.ID);
                 b.Click += new EventHandler(Soort_Click);
                 ly.AddView(b, Params);
             }
