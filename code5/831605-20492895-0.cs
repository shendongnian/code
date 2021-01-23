    //Main Window Code
    bool canRender = false;
    int y=0;
    foreach(MyData d in data)
    {
      //allocate control
      MyControl ctrl=new MyControl();
      //initialize properties
      ctrl.Name=d.Name;
      ctrl.Phone=d.Phone;
      //add control to canvas
      canvas.Children.Add(ctrl);
      //setup position
      Canvas.SetLeft(ctrl, 0);
      Canvas.SetTop(ctrl, y);
      y+=Height;
    }
    canRender = true;
    InvalidateVisual();
    //UserControl code
    protected override void OnRender(DrawingContext drawingContext)
    {
       if(!canRender)
          return;
    }
