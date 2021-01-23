	public static class Utils
	{
		public static bool SequencesMatch<TSource, TPattern>(IEnumerable<TSource> sequence, IEnumerable<TPattern> patterns, Func<TSource, TPattern, bool> matcher)
		{
			var items = sequence.Select(x => new SequenceItem<TSource>(x)).ToArray();
			var pats = patterns.Select(x => new SequenceItem<TPattern>(x)).ToArray();
		
			foreach (var item in items)
			{
				foreach (var pat in pats)
				{
					if (pat.Matched) continue;
					if (matcher(item.Value, pat.Value))
					{
						item.Matched = pat.Matched = true;
						break;
					}
				}
			}
		
			return items.All(x => x.Matched) && pats.All(x => x.Matched);
		}
		
		public static bool JsonObjectsMatch(JToken data, JToken reference)
		{
			if (reference.Type == JTokenType.Array)
				return SequencesMatch(data, reference, JsonObjectsMatch);
		
			if (reference.Type == JTokenType.Object)
			{
				var dataObj = data as JObject;
				var refObj = reference as JObject;
		
				if (dataObj == null || refObj == null)
					Assert.Fail("DataObject = '{0}', ReferenceObject = '{1}'", dataObj, refObj);
		
				foreach (var pty in refObj)
				{
					var dataValue = dataObj[pty.Key];
					if (dataValue == null || !JsonObjectsMatch(dataValue, pty.Value))
						Assert.Fail("Objects differ at {0}: DataValue = '{1}', RefValue = '{2}'", pty.Key, dataValue, pty.Value);
				}
		
				return true;
			}
		
			if (reference.Type == JTokenType.Float)
			{
				var refFloat = reference.ToObject<float>();
				var dataFloat = data.ToObject<float>();
		
				if(Math.Abs(dataFloat - refFloat) > 0.001)
					Assert.Fail("Objects differ: DataValue = '{0}', RefValue = '{1}'", dataFloat, refFloat);
		
				return true;
			}
		
			return JToken.DeepEquals(data, reference);
		}
		
		private class SequenceItem<T>
		{
			public T Value { get; set; }
			public bool Matched { get; set; }
		
			public SequenceItem(T value)
			{
				Value = value;
			}
		}
	}
