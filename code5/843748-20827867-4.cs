	public class KendoValueProvider : NameValueCollectionValueProvider
	{
		public KendoValueProvider(NameValueCollection originalCollection)
			: base(UpdateCollection(originalCollection), CultureInfo.InvariantCulture)
		{
		}
		private static NameValueCollection UpdateCollection(NameValueCollection collection)
		{
			NameValueCollection result = new NameValueCollection();
			foreach (string key in collection.Keys)
			{
				// ignore all other request
				if (!key.StartsWith("filter"))
					return null;
				var newKey = key
					.Replace("[filters]", string.Empty)
					.Replace("filter[logic]", "logic")
					.Replace("[value]", ".value")
					.Replace("[operator]", ".oper")
					.Replace("[field]", ".field")
					.Replace("[ignoreCase]", ".ignoreCase");
				var value = collection[key];
				result.Add(newKey, value);
			}
			return result;
		}
	}
