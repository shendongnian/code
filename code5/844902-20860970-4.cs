    ...
    gridTitle.MouseLeftButtonDown += gridTitle_MouseLeftButtonDown;
    //gridTitle.MouseMove += gridTitle_MouseMove;
    //The parent Window isn't available yet here in the constructor,
    //so we must wait for our Loaded event to hook it up:
    this.Loaded += (s, e) => { Window.GetWindow(this).MouseMove += gridTitle_MouseMove; };
    gridTitle.MouseLeftButtonUp += gridTitle_MouseLeftButtonUp;
    ...
