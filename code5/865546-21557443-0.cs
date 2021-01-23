    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication26
    {
    	public class AutoSizingColumnsWrapPanel : Panel
    	{
    		// The least acceptable width of the columns show in the panel. 
    		public double MinColumnWidth { get; set; }
    		// Spacing between columns.
    		public double HorizontalColumnPadding { get; set; }
    		// If a vertical line should be shown between the columns.
    		public bool ShowColumnSeparator { get; set; }
    		// The pen used to draw the column separator.
    		public System.Windows.Media.Pen ColumnSeparatorPen { get; set; }
    
    		private double _columnWidth = 0;
    		private int _numberOfColumns = 0;
    
    		public AutoSizingColumnsWrapPanel()
    		{
    			MinColumnWidth = 100;
    			ShowColumnSeparator = true;
    			HorizontalColumnPadding = 2.5;
    			ColumnSeparatorPen = new System.Windows.Media.Pen(SystemColors.ActiveBorderBrush, 1);
    		}
    
    		protected override void OnRender(System.Windows.Media.DrawingContext dc)
    		{
    			if (ShowColumnSeparator)
    			{
    				// Draw vertical lines as column separators.
    				for (int i = 0; i < _numberOfColumns - 1; i++)
    				{
    					double x = (i * HorizontalColumnPadding * 2) + (i + 1) * _columnWidth + HorizontalColumnPadding;
    					dc.DrawLine(ColumnSeparatorPen, new Point(x, 0), new Point(x, ActualHeight));
    				}
    			}
    			base.OnRender(dc);
    		}
    
    		protected override System.Windows.Size MeasureOverride(System.Windows.Size availableSize)
    		{
    			return DoLayout(availableSize, (uiElement, size, pos) => uiElement.Measure(size));
    		}
    
    		protected override System.Windows.Size ArrangeOverride(System.Windows.Size finalSize)
    		{
    			return DoLayout(finalSize, (uiElement, size, pos) => uiElement.Arrange(pos));
    		}
    
    		private Size DoLayout(Size availableSize, Action<UIElement, Size, Rect> layoutAction)
    		{
    			// Calculate number of columns and column width
    			int numberOfColumns = 0;
    			double columnWidth = MinColumnWidth;
    			if (double.IsInfinity(availableSize.Width))
    			{
    				numberOfColumns = InternalChildren.Count;
    			}
    			else
    			{
    				numberOfColumns = (int)Math.Max(Math.Floor(availableSize.Width / MinColumnWidth), 1);
    				// Give the columns equal space. Subtract any margin needed (MarginWidth is applied to both sides of the column, but not before the first column or after the last). The margin may cause the column to be smaller than MinColumnWidth.
    				columnWidth = ((availableSize.Width - ((numberOfColumns - 1) * HorizontalColumnPadding * 2)) / numberOfColumns);
    			}
    
    			// Init layout parameters
    			Size measureSize = new Size(columnWidth, availableSize.Height);
    			int currentColumn = 0;
    			int currentRow = 0;
    			double currentY = 0;
    			double currentRowHeight = 0;
    			// Place all items.
    			foreach (UIElement item in InternalChildren)
    			{
    				var position = new Rect((currentColumn * HorizontalColumnPadding * 2) + (currentColumn * columnWidth), currentY, columnWidth, item.DesiredSize.Height);
    				currentColumn++;
    				// Execute action passing: item = The child item to layout | measureSize = The size allocated for the child item | position = The final position and height of the child item.
    				layoutAction(item, measureSize, position);
    				// Keep the highest item on the row (so that we know where to start the next row).
    				currentRowHeight = Math.Max(currentRowHeight, item.DesiredSize.Height);
    				if (currentColumn == numberOfColumns)
    				{
    					// The item placed was in the last column. Increment/reset layout counters.
    					currentRow++;
    					currentColumn = 0;
    					currentY += currentRowHeight;
    					currentRowHeight = 0;
    				}
    			}
    
    			_columnWidth = columnWidth;
    			_numberOfColumns = numberOfColumns;
    
    			// Return total size of the items/panel.
    			return new Size(numberOfColumns * columnWidth + ((numberOfColumns - 1) * HorizontalColumnPadding * 2), currentY + currentRowHeight);
    		}
    	}
    }
