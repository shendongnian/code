    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        // overlay is the OverlayWithGaps instance   
        // in the window
        overlay.Gaps = new ObservableCollection<Rect>(
            itemsControl1.FindAllVisualDescendants()
                .OfType<Grid>()
                .Select(grid => {
                    Point relativePoint = grid.TransformToAncestor(this)
                        .Transform(new Point(0, 0));
                    return new Rect(relativePoint.X, 
                        relativePoint.Y, 
                        grid.ActualWidth, 
                        grid.ActualHeight
                    );
                })
        );
    }
