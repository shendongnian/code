	[Export(typeof(IViewTaggerProvider))]
	[ContentType("text")]
	[TextViewRole(PredefinedTextViewRoles.Document)]	
	[TagType(typeof(MyTag))]
	internal class MyTaggerProvider : IViewTaggerProvider
	{
		public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
		{
			return new MyTagger(this) as ITagger<T>;
		}
	}
