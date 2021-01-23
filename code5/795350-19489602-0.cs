		public class ImageViewAlphaTargetBinding : MvxAndroidTargetBinding
		{
			public ImageViewAlphaTargetBinding (ImageView target) : base(target)
			{
			}
			protected override void SetValueImpl(object target, object value)
			{
				var imageView = (ImageView)target;
				imageView.SetMyProperty((int)value);
			}
			public override Type TargetType
			{
				get { return typeof(int); }
			}
		}
