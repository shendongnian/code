		//Entity Dependency Property
		public object Entity
		{
			get { return (object)GetValue(EntityProperty); }
			set { SetValue(EntityProperty, value); }
		}
		public static readonly DependencyProperty EntityProperty =
			DependencyProperty.Register("Entity", typeof(object), 
			typeof(BaseEditEntityControl),
			new UIPropertyMetadata(null),
			(d, e) => { FillPropertyControls(); });
