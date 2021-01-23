    LinearLayout scrollContainer = new LinearLayout(Application.Context);
    scrollContainer.Orientation = Orientation.Vertical;
    View line = new View(Application.Context);
    line.Id = 1;
    line.SetBackgroundColor(Android.Graphics.Color.DarkGray); // the color you want
    line.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2); // 2 is the height you want
    scrollContainer.AddView(line);
