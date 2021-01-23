    public void ReorderDictionary(int oldIndex, int newIndex)
		{
			var oldDictionary = new Dictionary<int, string>();
			oldDictionary.Add(1, "item1");
			oldDictionary.Add(2, "item2");
			oldDictionary.Add(3, "item3");
			oldDictionary.Add(4, "item4");
			var movedItem = oldDictionary[oldIndex];
			oldDictionary.Remove(oldIndex);
			var newDictionary = new Dictionary<int, string>();
			var offset = 0;
			for (var i = 0; i < oldDictionary.Count; i++)
			{
				if (i + 1 == newIndex)
				{
					newDictionary.Add(i, movedItem);
					offset = 1;
				}
				var oldEvent = oldDictionary[oldDictionary.Keys.ElementAt(i)];
				newDictionary.Add(i + offset, oldEvent);
			}
			if (newIndex > oldDictionary.Count)
			{
				newDictionary.Add(oldDictionary.Count + 1, movedItem);
			}
		}
