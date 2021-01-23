    public static class Extension
    {
        public static void Update<T>(this List<T> items, T newItem)
        {	
		    var childList = items as List<Child>;
		    var newChildItem = newItem as Child;
            var matches = childList.Where(x => x.TrackingNumber == newChildItem.TrackingNumber).ToList();
		    matches.ForEach(x => childList[childList.IndexOf(x)] = newChildItem);
        }
    }
