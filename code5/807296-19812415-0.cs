         private void Slider_position(object sender, System.Windows.Controls.Slider e,    System.Windows.Input.MouseEventArgs e1)
        {
            if (e1.RightButton == MouseButtonState.Pressed)
            {
                Line line = new Line();
                line.X1 = e. //something, i would get here the coordinates X,Y of slider here
                // calculation from slider position to canvas position
                // draw a line of the height of the canvas here after
    
            }
        }
