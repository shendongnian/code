    private void timer_Tick(object sender, EventArgs e)
            {
                TouchCollection touchCollection = TouchPanel.GetState();
                var element = ContentPanel as UIElement;
    
                foreach (TouchLocation tl in touchCollection)
                {
                    if ((tl.State == TouchLocationState.Pressed)
                            || (tl.State == TouchLocationState.Moved))
                    {
                        var controls = VisualTreeHelper.FindElementsInHostCoordinates(new System.Windows.Point(tl.Position.X, tl.Position.Y), element);
                    }
                }
            }
