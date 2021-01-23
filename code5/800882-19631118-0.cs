	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public class TAXYEARCollection : ArrayList
	{
		public DateTime Add(DateTime obj)
		{
			base.Add(obj);
			return obj;
		}
		public DateTime Add()
		{
			return Add(new DateTime());
		}
		public void Insert(int index, DateTime obj)
		{
			base.Insert(index, obj);
		}
		public void Remove(DateTime obj)
		{
			base.Remove(obj);
		}
		new public DateTime this[int index]
		{
			get { return (DateTime) base[index]; }
			set { base[index] = value; }
		}
	}
