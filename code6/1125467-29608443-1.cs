		protected static void RenderTransform_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Test obj = (Test)d; // my control
			Transform x = obj.RenderTransform; // new rendertransform
			if (x.IsFrozen == false)
			{
				x.Changed += obj.RenderTransform_Changed;
			}
			// do anything
		}
