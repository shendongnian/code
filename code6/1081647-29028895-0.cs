     public DependencyProperty LocationProperty = DependencyProperty.Register(
	"Location", typeof(GeoCoordinate), typeof(MapBehavior), new PropertyMetadata(null, (sender, args) =>
	{
		if (args.NewValue != null && args.NewValue != args.OldValue)
		{
		    var sendMap = ((MapBehavior)sender);
		    sendMap.AssociatedObject.SetView((GeoCoordinate)args.NewValue, 14, 0, 0, MapAnimationKind.Parabolic);
		}
	}));
