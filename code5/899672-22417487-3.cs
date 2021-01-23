    namespace MegaHash
    {
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	public class GenericConcurrentMegaHash<T>
	{
		// After doing a bulk add, call AwaitAll() to ensure all data was added!
		private ConcurrentBag<Task> bag = new ConcurrentBag<Task>();
		private ConcurrentDictionary<string, List<T>> dictionary = new ConcurrentDictionary<string, List<T>>();
		// consider changing this to include for example '-'
		public char[] splitChars;
		public GenericConcurrentMegaHash()
			: this(new char[] { ' ' })
		{
		}
		public GenericConcurrentMegaHash(char[] splitChars)
		{
			this.splitChars = splitChars;
		}
		public void Add(string keyWords, T o)
		{
			keyWords = keyWords.ToUpper();
			foreach (string keyWord in keyWords.Split(splitChars))
			{
				if (keyWord == null || keyWord.Length < 1)
					return;
				this.bag.Add(Task.Factory.StartNew(() => { AddInternal(keyWord, o); }));
			}
		}
		public void AwaitAll()
		{
			lock (this.bag)
			{
				foreach (Task t in bag)
					t.Wait();
				this.bag = new ConcurrentBag<Task>();
			}
		}
		private void AddInternal(string key, T y)
		{
			for (int i = 0; i < key.Length; i++)
			{
				for (int i2 = 0; i2 < i + 1; i2++)
				{
					string desire = key.Substring(i2, key.Length - i);
					if (dictionary.ContainsKey(desire))
					{
						List<T> l = dictionary[desire];
						lock (l)
						{
							try
							{
								if (!l.Contains(y))
									l.Add(y);
							}
							catch (Exception ex)
							{
								ex.ToString();
							}
						}
					}
					else
					{
						List<T> l = new List<T>();
						l.Add(y);
						dictionary[desire] = l;
					}
				}
			}
		}
		public IList<T> FulltextSearch(string searchString)
		{
			searchString = searchString.ToUpper();
			List<T> list = new List<T>();
			string[] searchWords = searchString.Split(splitChars);
			foreach (string arg in searchWords)
			{
				if (arg == null || arg.Length < 1)
					continue;
				if (dictionary.ContainsKey(arg))
					foreach (T obj in dictionary[arg])
						if (!list.Contains(obj))
							list.Add(obj);
			}
			List<T> returnList = new List<T>();
			foreach (T o in list)
			{
				foreach (string arg in searchWords)
					if (dictionary[arg] == null || !dictionary[arg].Contains(o))
						goto BREAK;
				returnList.Add(o);
			BREAK:
				continue;
			}
			return returnList;
		}
	}
}
