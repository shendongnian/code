	using System;
	using System.Linq;
	class Solution 
    {
		public int[] solution(int N, int[] A) 
        {
			
			var currentMax = 0;
			var resetValue = 0;
			var counters = Enumerable.Range(1, N).ToDictionary(i => i, i => 0);
			foreach (var a in A)
			{
				if (a == N + 1) resetValue = currentMax;
				else
				{
					counters[a] = Math.Max(counters[a], resetValue) + 1;
					currentMax = Math.Max(currentMax, counters[a]);
				}
			}
			return counters.Values.Select(v => Math.Max(v,resetValue)).ToArray();
		}
	}
