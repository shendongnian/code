    static class GenericUtils
    {
        public static IEnumerable<T> GetItemsAsT<T>(this object[] objects) 
        where T:class
        {
            foreach(var obj in objects)
            {
	            var t = obj as T;
                if(t != null)
					yield return t;
			}
			yield break;
		}
		public static IEnumerable<T> GetItemsWhere<T>(this object[] objects, Predicate<T> predicate) 
			where T:class
		{
			foreach(var tObj in objects.GetItemsAsT<T>())
			{
				if(predicate(tObj))
				{
					yield return tObj;
				}
			}
			yield break;
		}
	}
