	using System;
	using System.Collections.Generic;
	using System.Text;
	namespace ConsoleApplication17
	{
		class CachedMerger
		{
			private Dictionary<HashSet<int>, string> _cache = new Dictionary<HashSet<int>, string>();
			private Dictionary<int, string> _items = new Dictionary<int, string>();
			public void AddItem(int index, string item)
			{
				_items[index] = item;
			}
			public void RemoveItem(int index)
			{
				_items.Remove(index);
			}
			private string Merge(string a, string b)
			{
				return a + b;
			}
			private string Merge(HashSet<int> list)
			{
				var sb = new StringBuilder();
				foreach (var index in list)
				{
					if (!_items.ContainsKey(index))
						return null;
					else
						sb.Append(_items[index]);
				}
				return sb.ToString();         
			}
			public string Get(HashSet<int> query)
			{
				var bestMatchKey = BestMatchKey(query);
				if (bestMatchKey == null)
				{
					var result = Merge(query);
					if (result == null)
						throw new Exception("Requested item not found in the item list.");
					_cache[query] = result;
					return result;
				}
				else
				{
					if (bestMatchKey.Count == query.Count)
						return _cache[bestMatchKey];
					var missing = new HashSet<int>();
					foreach (var index in query)
						if (!bestMatchKey.Contains(index))
							missing.Add(index);
					return Merge(_cache[bestMatchKey], Get(missing));
				}
			}
			private HashSet<int> BestMatchKey(HashSet<int> set)
			{
				int bestCount = 0;
				HashSet<int> bestKey = null;
				foreach (var entry in _cache)
				{
					var key = entry.Key;
					int count = 0;
					bool fail = false;
					foreach (var i in key)
					{
						if (set.Contains(i))
						{
							count++;
						}
						else
						{
							fail = true;
							break;
						}
					}
					
					if (!fail && count > bestCount)
					{
						bestKey = key;
						bestCount = count;
					}
				}
				return bestKey;
			}
		}
		class Program
		{
			static void Main(string[] args)
			{
				var cm = new CachedMerger();
				// Add all the base parts
				cm.AddItem(0, "sjkdlajkld");
				cm.AddItem(1, "dffdfdfdf");
				cm.AddItem(2, "qwqwqw");
				cm.AddItem(3, "yuyuyuyy");
				cm.AddItem(4, "kjkjkjkjkj");
				cm.AddItem(5, "oioyuyiyui");
				// This will merge 0 + 1 + 3 + 4 since the cache is empty
				Console.WriteLine(cm.Get(new HashSet<int> { 0, 1, 3, 4 }));
				// This will merge 2 + 5 as there is no match in the cache
				Console.WriteLine(cm.Get(new HashSet<int> { 2, 5 }));
				// This will merge (2 + 5) from the cache with 3
				Console.WriteLine(cm.Get(new HashSet<int> { 2, 3, 5 }));
				// This will merge (0 + 1 + 3 + 4) from the cache with (2 + 5) from the cache
				Console.WriteLine(cm.Get(new HashSet<int> { 0, 1, 2, 3, 4, 5 }));
				Console.Read();
			}
		}
	}
