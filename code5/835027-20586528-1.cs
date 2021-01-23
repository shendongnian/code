		static void Main(string[] args)
		{
			// create/read sets here
			var integers = new List<int[]>(){new []{1,2,4}, new []{1,3}, new []{2, 4}, new []{2, 7}, new []{3, 6}, new []{5, 6}, new []{2, 5, 7}};
			// allocate/populate booleans - loop may be able to be refined
			var conflicts = new bool[integers.Count, integers.Count];
			for (var idx = 0; idx < integers.Count; idx++)
				for (var cmpIdx = 0; cmpIdx < integers.Count; cmpIdx++)
					conflicts[idx, cmpIdx] = integers[idx].Any(x => integers[cmpIdx].Contains(x));
			// find combinations (index combinations)
			var combinations = GetCombinations(integers.Count);
			// remove invalid entries
			for (var idx = 0; idx < combinations.Count; idx++)
				if (HasConflict(combinations[idx], conflicts))
					combinations.RemoveAt(idx--);
			// print out the final result
			foreach (var combination in combinations) PrintCombination(combination, integers);
			// pause
			Console.ReadKey();
		}
		// get all combinatins
		static List<Combination> GetCombinations(int TotalLists)
		{
			var result = new List<Combination>();
			for (var combinationCount = 1; combinationCount <= TotalLists; combinationCount++)
				result.AddRange(GetCombinations(TotalLists, combinationCount));
			return result;
		}
		static List<Combination> GetCombinations(int TotalLists, int combinationCount)
		{
			return GetCombinations(TotalLists, combinationCount, 0, new List<int>());
		}
		// recursive combinatorics - loads of alternatives including linq cartesian coordinates
		static List<Combination> GetCombinations(int TotalLists, int combinationCount, int minimumStart, List<int> currentList)
		{
			// stops endless recursion - forms final result
			var result = new List<Combination>();
			if (combinationCount <= 0)
			{
				if ((currentList ?? new List<int>()).Count > 0)
				{
					result.Add(new Combination() { sets = currentList });
					return result;
				}
				return null;
			}
			for (var idx = minimumStart; idx <= TotalLists - combinationCount; idx++)
			{
				var nextList = new List<int>();
				nextList.AddRange(currentList);
				nextList.Add(idx);
				var combinations = GetCombinations(TotalLists, combinationCount - 1, idx + 1, nextList);
				if (combinations != null) result.AddRange(combinations);
			}
			return result;
		}
		// print the combination
		static void PrintCombination(Combination value, List<int[]> sets)
		{
			StringBuilder serializedSets = new StringBuilder();
			foreach (var idx in value.sets)
			{
				if (serializedSets.Length > 0) serializedSets.Append(", ");
				else serializedSets.Append("{");
				serializedSets.Append("{");
				for (var setIdx = 0; setIdx < sets[idx].Length; setIdx++)
				{
					if (setIdx > 0) serializedSets.Append(", ");
					serializedSets.Append(sets[idx][setIdx].ToString());
				}
				serializedSets.Append("}");
			}
			serializedSets.Append("}");
			Console.WriteLine(serializedSets.ToString());
		}
		static bool HasConflict(Combination value, bool[,] conflicts)
		{
			for (var idx = 0; idx < value.sets.Count; idx++)
				for (var cmpIdx = idx + 1; cmpIdx < value.sets.Count; cmpIdx++)
					if (conflicts[value.sets[idx], value.sets[cmpIdx]]) return true;
			return false;
		}
		// internal class to manage combinations
		class Combination { public List<int> sets; }
