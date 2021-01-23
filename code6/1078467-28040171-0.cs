    Grid grid = new System.Windows.Controls.Grid() { Background = Brushes.Blue, Width = 200, Height = 200 };
    Viewbox viewbox = new Viewbox();
    viewbox.Child = grid; //control to render
    viewbox.Measure(new System.Windows.Size(200, 200));
    viewbox.Arrange(new Rect(0, 0, 200, 200));
    viewbox.UpdateLayout();
    RenderTargetBitmap render = new RenderTargetBitmap(200, 200, 150, 150, PixelFormats.Pbgra32);
    render.Render(viewbox);
