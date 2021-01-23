		/// <summary>
		/// Use this extension method to update an observable collection without recreating it. This method keeps also track of the order items of the new collection.
		/// </summary>
		/// <remarks>This method was intended for short collection. The base complexity is around O(n+m) but the use of the IndexOf method make the complexity O(n*m)...O((n+m)*m).</remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="collection">The collection to update.</param>
		/// <param name="newCollection">The source of the new items.</param>
		public static void UpdateCollection<T>(this ObservableCollection<T> collection, IList<T> newCollection)
		{
			if ((null == newCollection) || (newCollection.Count == 0))
			{
				collection.Clear();
				return;
			}
			var i = 0;
			foreach (var it in newCollection)
			{
				if (collection.Count > i)
				{
					var itemIndex = collection.IndexOf(it);
					// This method would be match better, but it does not exist ;)
					//var remaining = list.Count - i;
					//itemIndex = list.IndexOf(it, i, remaining);
					if (itemIndex < 0)
					{
						// this item was not found in the list
						collection.Insert(i, it);
					}
					else if (itemIndex > i)
					{
						// item is in the list but on a different place
						collection.Move(itemIndex, i);
					}
					else
					{
						// here the 'itemIndex' is less than or equal to 'i' --> we may have duplicate item 
						// we check if the current items are the same!?
						if (!EqualityComparer<T>.Default.Equals(collection[i], it))
						{
							// the items are different! The question is: do we need this item later?
							// --> maybe: we keep (higher complexity)
							collection.Insert(i, it);
							// --> not: we can replace (lower complexity)
							// list[i] = it;
						}
						else
						{
							// yop: the items are the same, we do nothing.
						}
					}
				}
				else
				{
					// add new item
					collection.Add(it);
				}
				i++;
			}
			// we remove the remaining items.
			while (collection.Count > newCollection.Count) {
				collection.RemoveAt(i);
			};
		}
