	public class SelectListItem<T> : SelectListItem
	{
		[JsonIgnore] // Added so the Json.NET serializer would ignore this property
		public T ValueSetter {
			set {
				Value = value.ToString();
			}
			// I only have a getter because AutoMapper for some reason requires it
			get {
				return default(T);
			}
		}
	}
