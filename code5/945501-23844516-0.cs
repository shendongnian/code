	public abstract class TextElement : ITextElement
	{
		public string Text { get { return GetText(); } }
		protected abstract string GetText();
	}
	public abstract class TextElementUpdatable : TextElement, ITextElementUpdatable
	{
		string ITextElementUpdatable.Text
		{
			get { return GetText(); }
			set { SetText(value); }
		}
		protected abstract void SetText(string text);
	}
