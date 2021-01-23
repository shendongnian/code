    protected void Draw(DrawingContext drawingContext)
        {
            var wrapper = new Canvas();
            // ...
            wrapper.Children.Add(canvas);
            wrapper.Children.Add(panel);
            Content = wrapper;
        }
