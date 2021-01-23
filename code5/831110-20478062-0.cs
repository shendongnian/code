		/// <summary>
		/// Gets a specified set of values from a string
		/// </summary>
		/// <param name="set">The 1-based numbered set.  To get the second set, pass 2.</param>
		/// <param name="str">A space-separated string with all of the values</param>
		/// <returns>A space-separated string with the specified set of values.</returns>
		private static string GetNthSet(int set, string str)
		{
			string output = string.Empty;
			string[] parts = str.Split(' ');
			List<string> used = new List<string>();
			foreach (var part in parts)
			{
				if(!used.Contains(part))
				{
					used.Add(part);
				}
				if(used.Count == set)
				{
					output += part + " ";
				}
				else if(used.Count > set)
				{
					break;
				}
			}
			return output.Trim();
		}
