	sortedNodes.Sort((a, b) =>
		{
			var aDistToNext = Math.Abs(a.Value - a.NextNode.Value);
			var bDistToNext = Math.Abs(b.Value - b.NextNode.Value);
			var result = aDistToNext.CompareTo(bDistToNext);
			if (result != 0)
				return result;
			else
			{
				var aNextDistToNext = Math.Abs(a.NextNode.Value - a.NextNode.NextNode.Value);
				var bNextDistToNext = Math.Abs(b.NextNode.Value - b.NextNode.NextNode.Value);
				return bNextDistToNext.CompareTo(aNextDistToNext);
			}
		});
