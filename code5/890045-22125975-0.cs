	public class AutoPanel : Panel
	{
		public AutoPanel()
		{
			AutoScroll = true;
		}
		private int _nextOffset = 0;
		public int ItemMarginX = 5;
		public int ItemMarginY = 5;
		public void Add(Control child)
		{
			child.Location = new Point(ItemMarginX, _nextOffset);
			_nextOffset += (child.Height + ItemMarginY);
			Controls.Add(child);
		}
	}
