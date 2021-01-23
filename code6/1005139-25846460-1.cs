	public class CustomRichTextBox: RichTextBox
	{
		public CustomRichTextBox()
		{
			DataObject.AddCopyingHandler(this, OnCopy);
		}
		private void OnCopy(object sender, DataObjectCopyingEventArgs e)
		{
			if(e.DataObject != null)
			{
				UpdateDocument();
				var range = new TextRange(Selection.Start, Selection.End);
				using(var ms = new MemoryStream())
				{
					range.Save(ms, DataFormats.Xaml, true);
					ms.Position = 0;
					using(var reader = new StreamReader(ms, Encoding.UTF8))
					{
						var xaml = reader.ReadToEnd();
						e.DataObject.SetData(DataFormats.Xaml, xaml);
					}
				}
				e.Handled = true;
			}
		}
		public void UpdateDocument()
		{
			ObjectHelper.ExecuteRecursive<InlineMedia>(Document, i => i.UpdateChildSource(), FlowDocumentVisitors);
		}
		private static readonly Func<object, object>[] FlowDocumentVisitors =
		{
			x => (x is FlowDocument) ? ((FlowDocument) x).Blocks : null,
			x => (x is Section) ? ((Section) x).Blocks : null,
			x => (x is BlockUIContainer) ? ((BlockUIContainer) x).Child : null,
			x => (x is InlineUIContainer) ? ((InlineUIContainer) x).Child : null,
			x => (x is Span) ? ((Span) x).Inlines : null,
			x => (x is Paragraph) ? ((Paragraph) x).Inlines : null,
			x => (x is Table) ? ((Table) x).RowGroups : null,
			x => (x is Table) ? ((Table) x).Columns : null,
			x => (x is Table) ? ((Table) x).RowGroups.SelectMany(rg => rg.Rows) : null,
			x => (x is Table) ? ((Table) x).RowGroups.SelectMany(rg => rg.Rows).SelectMany(r => r.Cells) : null,
			x => (x is TableCell) ? ((TableCell) x).Blocks : null,
			x => (x is TableCell) ? ((TableCell) x).BorderBrush : null,
			x => (x is List) ? ((List) x).ListItems : null,
			x => (x is ListItem) ? ((ListItem) x).Blocks : null
		};
	}
