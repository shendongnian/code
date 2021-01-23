    ... OnPointerMoved(PointerRoutedEventArgs e)
    {
    	PointerPoint point = e.GetCurrentPoint(page);
    	if (point.Position.Y > page.RenderSize.Height - 5)
    	{
    		page.MainMenu.IsOpen = true;
    	}
    }
