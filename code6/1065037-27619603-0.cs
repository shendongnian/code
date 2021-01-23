	public class CollapsingPanel : Panel
	{
		/// <summary>
		/// parents are supposed to ask their children what their desired size is, given an available size
		/// </summary>
		/// <param name="availableSize"></param>
		/// <returns></returns>
		protected override Size MeasureOverride(Size availableSize)
		{
			var availableSizeOnThisLine = new Rect(new Point(0, 0), new Size(availableSize.Width, 0));
			var panelDesiredSize = new Size(availableSize.Width, 0);
			foreach (FrameworkElement child in InternalChildren)
			{
				child.Measure(availableSize);
				var childSize = child.DesiredSize;
				if (childSize.Width > availableSizeOnThisLine.Size.Width)
				{
					// this child will overflow this line: New line!
					panelDesiredSize.Height += availableSizeOnThisLine.Height;
					availableSizeOnThisLine = new Rect(new Point(0, panelDesiredSize.Height), new Size(availableSize.Width, childSize.Height));
					availableSizeOnThisLine.Width -= childSize.Width; // subtract this area/width
					availableSizeOnThisLine.Height = childSize.Height;
				}
				else
				{
					// this child will fit on this line..
					var thisChildRectangle = new Rect(childSize);
					if (child.HorizontalAlignment == HorizontalAlignment.Left)
					{
						thisChildRectangle.Location = new Point(availableSizeOnThisLine.Left, availableSizeOnThisLine.Top);
						availableSizeOnThisLine.Location.Offset(childSize.Width, 0); // move to the right
					} 
					else if (child.HorizontalAlignment == HorizontalAlignment.Right)
					{
						thisChildRectangle.Location = new Point(availableSizeOnThisLine.Right - childSize.Width, availableSizeOnThisLine.Top);
					}
					child.Arrange(thisChildRectangle);
					availableSizeOnThisLine.Width -= childSize.Width; // subtract child's width from avbailable space
					availableSizeOnThisLine.Height = Math.Max(availableSizeOnThisLine.Height, childSize.Height);
					panelDesiredSize.Height = Math.Max(childSize.Height, panelDesiredSize.Height);
				}
			}
			return panelDesiredSize;
		}
		/// <summary>
		/// parents position their children and tell their children how much size they are actually getting
		/// </summary>
		/// <param name="finalSize"></param>
		/// <returns></returns>
		protected override Size ArrangeOverride(Size finalSize)
		{
			var availableSizeOnThisLine = new Rect(new Point(0, 0), new Size(finalSize.Width, 0));
			foreach (FrameworkElement child in InternalChildren)
			{
				var childSize = child.DesiredSize;
				if (childSize.Width > availableSizeOnThisLine.Size.Width) 
				{
					// going to wrap around
					var thisChildRectangle = new Rect(child.DesiredSize);
					availableSizeOnThisLine = new Rect(new Point(0, availableSizeOnThisLine.Height), new Size(finalSize.Width, childSize.Height));
					if (child.HorizontalAlignment == HorizontalAlignment.Right)
					{
						thisChildRectangle.Location = new Point(availableSizeOnThisLine.Right - thisChildRectangle.Width, availableSizeOnThisLine.Top);
					}
					else if (child.HorizontalAlignment == HorizontalAlignment.Left)
					{
						thisChildRectangle.Location = new Point(availableSizeOnThisLine.Left, availableSizeOnThisLine.Top);
					}
					child.Arrange(thisChildRectangle);
				}
				else
				{
					// put on this line
					var thisChildRectangle = new Rect(child.DesiredSize);
					if (child.HorizontalAlignment == HorizontalAlignment.Right)
					{
						thisChildRectangle.Location = new Point(availableSizeOnThisLine.Right - thisChildRectangle.Width, availableSizeOnThisLine.Top);
					}
					else if (child.HorizontalAlignment == HorizontalAlignment.Left)
					{
						thisChildRectangle.Location = new Point(availableSizeOnThisLine.Left, availableSizeOnThisLine.Top);
					}
					child.Arrange(thisChildRectangle);
					availableSizeOnThisLine.Width -= thisChildRectangle.Width; // subtract child's width from avbailable space
				}
				availableSizeOnThisLine.Height = Math.Max(childSize.Height, availableSizeOnThisLine.Height);
			}
			return finalSize;
		}
