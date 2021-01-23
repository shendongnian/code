	public class SelectListItem<T> : SelectListItem
	{
		[JsonIgnore] // Added so the Json.NET serializer would ignore this property
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
