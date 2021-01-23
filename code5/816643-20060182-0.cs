	[ContentProperty("Inlines")]
	[TemplatePart(Name = "PART_InlinesPresenter", Type = typeof(TextBlock))]
	public class GradientTitle : Control
	{
		private readonly Collection<Inline> _inlines = new Collection<Inline>();
		public Collection<Inline> Inlines
		{
			get { return _inlines; }
		}
		static GradientTitle()
		{
			DefaultStyleKeyProperty.OverrideMetadata(
				typeof(GradientTitle),
				new FrameworkPropertyMetadata(typeof(GradientTitle)));
		}
		public override void OnApplyTemplate()
		{
			base.ApplyTemplate();
			var inlinesPresenter = GetTemplateChild("PART_InlinesPresenter") as TextBlock;
			if(inlinesPresenter != null)
			{
				var targetInlines = inlinesPresenter.Inlines;
				foreach(var inline in Inlines)
				{
					targetInlines.Add(inline);
				}
			}
		}
	}
