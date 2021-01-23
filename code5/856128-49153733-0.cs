    public partial class LabelWithBorder
		: UILabel
	{
		private UIEdgeInsets EdgeInsets = new UIEdgeInsets(5, 5, 5, 5);
		private UIEdgeInsets InverseEdgeInsets = new UIEdgeInsets(5, 5, 5, 5);
		public LabelWithBorder(IntPtr handle) : base(handle)
		{
		}
		public override CoreGraphics.CGRect TextRectForBounds(CoreGraphics.CGRect bounds, nint numberOfLines)
		{
			var textRect = base.TextRectForBounds(EdgeInsets.InsetRect(bounds), numberOfLines);
			return InverseEdgeInsets.InsetRect(textRect);
		}
		public override void DrawText(CoreGraphics.CGRect rect)
		{
			base.DrawText(EdgeInsets.InsetRect(rect));
		}
	}
