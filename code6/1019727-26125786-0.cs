	public class SampleEntityConverter : IDocumentConversionListener
	{
		public void EntityToDocument(string key, object entity, RavenJObject document, RavenJObject metadata)
		{
			var obj = entity as SampleEntity;
			if (obj == null)
			{
				return;
			}
			var integer = new RavenJObject();
			integer["Last Set"] = obj.HoweverYouGetTheLastSetDateTime;
			integer["Value"] = obj.Integer;
			document["Integer"] = integer;
		}
		public void DocumentToEntity(string key, object entity, RavenJObject document, RavenJObject metadata)
		{
			var obj = entity as SampleEntity;
			if (obj == null)
			{
				return;
			}
            var integer = document["Integer"] as RavenJObject;       
            if (integer != null && integer.ContainsKey("Value"))
            {
                obj.Integer = integer["Value"];
            }
		}
	}
