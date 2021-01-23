    private void AnimateRectangle(Rectangle rectangle, int sourceColumn, int sourceRow, int targetColumn, int targetRow)
    {
		rectangle.RenderTransform = new CompositeTransform();
			
        Storyboard s = new Storyboard();
        DoubleAnimation doubleAniColumn = new DoubleAnimation();
        doubleAniColumn.From = 0;
        doubleAniColumn.To = ...; // calculate correct offset here
        doubleAniColumn.Duration = new Duration(TimeSpan.FromMilliseconds(500));
        Storyboard.SetTarget(doubleAniColumn, rectangle);
        Storyboard.SetTargetProperty(doubleAniColumn, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.X)"));
        DoubleAnimation doubleAniRow = new DoubleAnimation();
        doubleAniRow.From = 0;
        doubleAniRow.To = ...; // calculate correct offset here
        doubleAniRow.Duration = new Duration(TimeSpan.FromMilliseconds(500));
        Storyboard.SetTarget(doubleAniRow, rectangle);
        Storyboard.SetTargetProperty(doubleAniRow, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.X)"));
        s.Children.Add(doubleAniColumn);
        s.Children.Add(doubleAniRow);
		EventHandler eventHandler = null;
		eventHandler = (s, o) =>
		{
			s.Completed -= eventHandler;
			Grid.SetRow(rectangle, targetRow);
			Grid.SetColumn(rectangle, targetColumn);
			rectangle.RenderTransform = new CompositeTransform();
		};
		s.Completed += eventHandler;
        s.Begin();
    }
