    private ConnectionPoint SelectedPoint { get; set; }
    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            // dragging something.. check if there is a point selected
            if (SelectedPoint != null)
            {
                 _viewModel.MovePointHandler(SelectedPoint, _oldLocation, _newLocation);
            }
        }
    }
