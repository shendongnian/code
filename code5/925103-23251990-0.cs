	public class ColorizeAvalonEdit : DocumentColorizingTransformer
	{
		protected override void ColorizeLine(DocumentLine line)
		{
			int lineStartOffset = line.Offset;
			string text = CurrentContext.Document.GetText(line);
			int start = 0;
			int index;
			while ((index = text.IndexOf("AvalonEdit", start, StringComparison.Ordinal)) >= 0) {
				base.ChangeLinePart(
					lineStartOffset + index, // startOffset
					lineStartOffset + index + 10, // endOffset
					(VisualLineElement element) => {
						// This lambda gets called once for every VisualLineElement
						// between the specified offsets.
						Typeface tf = element.TextRunProperties.Typeface;
						// Replace the typeface with a modified version of
						// the same typeface
						element.TextRunProperties.SetTypeface(new Typeface(
							tf.FontFamily,
							FontStyles.Italic,
							FontWeights.Bold,
							tf.Stretch
						));
					});
				start = index + 1; // search for next occurrence
			}
		}
	}
	// Usage:
	textEditor.TextArea.TextView.LineTransformers.Add(new ColorizeAvalonEdit());
