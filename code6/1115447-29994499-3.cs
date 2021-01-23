    public static class MapConfiguration
    {
		public static void MapCollection<T>(IEnumerable<ListItemViewModel<T>> source, ICollection<T> dest)
		{
			foreach (var sourceItem in source)
			{
				//user added and removed an item before saving, do nothing
				if (sourceItem.Insert && sourceItem.Delete) continue;
				//user added an item
				if (sourceItem.Insert)
				{
					var destItem = Mapper.Map<T>(sourceItem);
					sourceItem.OnAdd(destItem);
					dest.Add(destItem);
				}
				//user deleted an item
				else if (sourceItem.Delete)
				{
					//Using custom Equals implementation that compares PK
					var destItem = dest.First(d => sourceItem.Equals(d));
					sourceItem.OnRemove(destItem);
					dest.Remove(destItem);
				}
				//user modified or did not alter an item
				else
				{
					//Using custom Equals implementation that compares PK
					var destItem = dest.First(d => sourceItem.Equals(d));
					sourceItem.OnEdit(destItem);
					Mapper.Map(sourceItem, destItem);
				}
			}
		}
	}
