	public class TaggedAutoCompleteStringCollection : AutoCompleteStringCollection
	{
		private List<object> _tags;
		public TaggedAutoCompleteStringCollection()
			: base()
		{
			_tags = new List<object>();
		}
		public int Add(string value, object tag)
		{
			int result = this.Add(value);
			_tags.Add(tag);
			return result;
		}
		public void AddRange(string[] value, object[] tag)
		{
			base.AddRange(value);
			_tags.AddRange(tag);
		}
		public new void Clear()
		{
			base.Clear();
			_tags.Clear();
		}
		public bool ContainsTag(object tag)
		{
			return _tags.Contains(tag);
		}
		public int IndexOfTag(object tag)
		{
			return _tags.IndexOf(tag);
		}
		public void Insert(int index, string value, object tag)
		{
			base.Insert(index, value);
			_tags.Insert(index, tag);
		}
		public new void Remove(string value)
		{
			int index = this.IndexOf(value);
			if (index != -1)
			{
				base.RemoveAt(index);
				_tags.RemoveAt(index);
			}
		}
		public new void RemoveAt(int index)
		{
			base.RemoveAt(index);
			_tags.RemoveAt(index);
		}
		public object TagOfString(string value)
		{
			int index = base.IndexOf(value);
			if (index == -1)
			{
				return null;
			}
			return _tags[index];
		}
	}
	public static class TaggedAutoCompleteStringCollectionHelper
	{
		public static object GetTag(this TextBox control)
		{
			var source = control.AutoCompleteCustomSource as TaggedAutoCompleteStringCollection;
			if (source == null)
			{
				return null;
			}
			return source.TagOfString(control.Text);
		}
		public static object GetTag(this ComboBox control)
		{
			var source = control.DataSource as TaggedAutoCompleteStringCollection;
			if (source == null)
			{
				return null;
			}
			return source.TagOfString(control.Text);
		}
	}
