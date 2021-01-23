		// .... continuation of TableColumnIndexer class
		public List<string> GetShortestAncestry(string parentName, string targetName, int maxDepth)
		{
			return GetSortestAncestryR(parentName, targetName, maxDepth - 1, 0, new Dictionary<string,int>());
		}
		private List<string> GetSortestAncestryR(string currentName, string targetName, int maxDepth, int currentDepth, Dictionary<string, int> vistedTables)
		{
			// Check if we have visited this table before
			if (!vistedTables.ContainsKey(currentName))
				vistedTables.Add(currentName, currentDepth);
			// Make sure we have not visited this table at a shallower depth before
			if (vistedTables[currentName] < currentDepth)
				return null;
			else
				vistedTables[currentName] = currentDepth;
			if (currentDepth <= maxDepth)
			{
				List<string> result = new List<string>();
				// First check if the current table contains a reference to the target table
				if (tables[currentName].Contains(targetName))
				{
					result.Add(currentName);
					result.Add(targetName);
					return result;
				}
				// If not try to see if any of the children tables have the target table
				else
				{
					List<string> bestResult = null;
				        int bestDepth = int.MaxValue;
					foreach (string childTable in tables[currentName])
					{
						var tempResult = GetSortestAncestryR(childTable, targetName, maxDepth, currentDepth + 1, vistedTables);
						// Keep only the shortest path found to the target table
						if (tempResult != null && tempResult.Count < bestDepth)
						{
							bestDepth = tempResult.Count;
							bestResult = tempResult;
						}
					}
					// Take the best link we found and add it to the result list
					if (bestDepth < int.MaxValue && bestResult != null)
					{
						result.Add(currentName);
						result.AddRange(bestResult);
						return result;
					}
					// If we did not find any result, return nothing
					else
					{
						return null;
					}
				}
			}
			else
			{
				return null;
			}
		}
	}
