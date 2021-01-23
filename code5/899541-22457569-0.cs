    public class FilterAttribute : Attribute, IHasRequestFilter
	{
		IHasRequestFilter IHasRequestFilter.Copy()
		{
			return this;
		}
		public int Priority { get { return int.MinValue; } }
		FilterField CreateOrUpdateField(ref Dictionary<string, FilterField> filter, string id)
		{
			if(filter.ContainsKey(id))
				return filter[id];
			var field = new FilterField { Data = new Dictionary<string, object>() };
			filter.Add(id, field);
			return field;
		}
		public void RequestFilter(IRequest req, IResponse res, object requestDto)
		{
			var filteredDto = requestDto as IFilter;
			if(filteredDto == null)
				return;
			const string fieldPattern = @"filter\[([A-Za-z0-9]+)\]\[field\]";
			const string dataPattern = @"filter\[([A-Za-z0-9]+)\]\[data\]\[([A-Za-z0-9]+)\]";
			Dictionary<string, FilterField> filter = new Dictionary<string, FilterField>();
			foreach(var property in req.QueryString.AllKeys)
			{
				Match match = Regex.Match(property, fieldPattern, RegexOptions.IgnoreCase);
				if(match.Success)
				{
					// Field
					var id = match.Groups[1].Value;
					var field = CreateOrUpdateField(ref filter, id);
					field.Field = req.QueryString[property];
				} else {
					match = Regex.Match(property, dataPattern, RegexOptions.IgnoreCase);
					if(match.Success)
					{
						// Data value
						var id = match.Groups[1].Value;
						var keyName = match.Groups[2].Value;
						var field = CreateOrUpdateField(ref filter, id);
						if(!field.Data.ContainsKey(keyName))
							field.Data.Add(keyName, req.QueryString[property]);
					}
				}
			}
			filteredDto.Filter = filter.Values.ToArray();
		}
	}
