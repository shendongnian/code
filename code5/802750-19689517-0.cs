		/// <summary>
		/// Take an extended key and walk through an object to update it.
		/// </summary>
		/// <param name="o">The object to update</param>
		/// <param name="key">The key in the form of "NestedThing.List[2].key"</param>
		/// <param name="value">The value to update to</param>
		private static void UpdateModel(object o, string key, object value)
		{
			// TODO:
			// Make the code more efficient.
			var target = o;
			PropertyInfo pi = null;
			// Split the key into bits.
			var steps = key.Split('.').ToList();
			// Don't walk all the way to the end
			// Save that for the last step.
			var lastStep = steps[steps.Count-1];
			steps.RemoveAt(steps.Count-1);
			// Step through the bits.
			foreach (var bit in steps)
			{
				var step = bit;
				
				string index = null;
				// Is this an indexed property?
				if (step.EndsWith("]"))
				{
					// Extract out the value of the index
					var end = step.IndexOf("[", System.StringComparison.Ordinal);
					index = step.Substring(end+1, step.Length - end - 2);
					// and trim 'step' back down to exclude it.  (List[5] becomes List)
					step = step.Substring(0, end);
				}
				// Get the new target.
				pi = target.GetType().GetProperty(step);
				target = pi.GetValue(target);
				// If the target had an index, find it now.
				if (index != null)
				{
					var idx = Convert.ToInt16(index);
					// The most generic way to handle it.
					var list = (IEnumerable) target;
					foreach (var e in list)
					{
						if (idx ==0)
						{
							target = e;
							break;
						}
						idx--;
					}
				}
			}
			// Now at the end we can apply the last step,
			// actually setting the new value.
			if (pi != null || steps.Count == 0)
			{
				pi = target.GetType().GetProperty(lastStep);
				pi.SetValue(target, value);
			}
		}
