	public class SelectListItem<T> : SelectListItem
	{
		public new T Value {
			set {
				base.Value = value.ToString();
			}
			// Kind of a hack that I had to add 
			// otherwise the code won't compile
			get {
				return default(T);
			}
		}
	}
