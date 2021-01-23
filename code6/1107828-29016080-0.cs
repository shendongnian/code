    control.Tag = someObject;
    control.Click += (o, e) =>
    {
         Control c = o as Control;
         MyObject data = c.Tag as MyObject;
         //use data
    };
