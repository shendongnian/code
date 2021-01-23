	public class RadioTextblock : TextBlock
	{
		static RadioTextblock()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(RadioTextblock), new FrameworkPropertyMetadata(typeof(RadioTextblock)));
		}
		public static readonly DependencyProperty GroupProperty = DependencyProperty.Register(
			"Group", typeof (string), typeof (RadioTextblock), new PropertyMetadata(string.Empty));
		public string Group
		{
			get { return (string) GetValue(GroupProperty); }
			set { SetValue(GroupProperty, value); }
		}
		public static readonly DependencyProperty ActiveColorProperty = DependencyProperty.Register(
			"ActiveColor", typeof (Brush), typeof (RadioTextblock), new PropertyMetadata(default(Brush)));
		public Brush ActiveColor
		{
			get { return (Brush) GetValue(ActiveColorProperty); }
			set { SetValue(ActiveColorProperty, value); }
		}
		public static readonly DependencyProperty RestorationColorProperty = DependencyProperty.Register(
			"RestorationColor", typeof (Brush), typeof (RadioTextblock), new PropertyMetadata(default(Brush)));
		public Brush RestorationColor
		{
			get { return (Brush) GetValue(RestorationColorProperty); }
			set { SetValue(RestorationColorProperty, value); }
		}
		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			// there may be a better hook for this. but i'm not writing custom controls that often. anything after styles are applied should be good
			RestorationColor = Background;
		}
		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			RestoreOtherBackgrounds(this);
			base.OnPreviewMouseDown(e);
		}
		private void RestoreOtherBackgrounds(RadioTextblock radioTextblock)
		{
			var topParent = GetTopMostParent(radioTextblock);
			var controlsWithGroup = GetChildrenRecursive<RadioTextblock>(topParent).ToLookup(d => (string)d.GetValue(GroupProperty));
			var similar = controlsWithGroup[radioTextblock.Group];
			foreach (var match in similar)
			{
				if (match == radioTextblock)
				{
					match.Background = ActiveColor;
				}
				else
				{
					match.Background = match.RestorationColor;
				}
			}
		}
		private DependencyObject GetTopMostParent(RadioTextblock radioTextblock)
		{
			DependencyObject current = radioTextblock;
			while (current != null)
			{
				var cParent = VisualTreeHelper.GetParent(current);
				if (cParent == null || cParent == current)
					break;
				current = cParent;
			}
			return current;
		}
		private IEnumerable<T> GetChildrenRecursive<T>(DependencyObject current) where T : DependencyObject
		{
			T casted;
			var childCount = VisualTreeHelper.GetChildrenCount(current);
			for (int i = 0; i < childCount; i++)
			{
				var currentChild = VisualTreeHelper.GetChild(current, i);
				casted = currentChild as T;
				if(casted != null)
					yield return casted;
				foreach (var subChild in GetChildrenRecursive<T>(currentChild))
				{
					if (subChild != null)
						yield return casted;
				}
			}
		}
	}
