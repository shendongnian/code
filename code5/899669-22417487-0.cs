    namespace MegaHash
    {
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	/// <summary>
	/// This class enables blazingly fast .contains like search in a dictionary<string, object> style 
	/// Performance hints:
	/// higher process priority speeds this class up significantly
	/// using .net Framework 4.5.1 seems to speed this class up
	/// 64 bit versions run significantly faster
	/// optimized builds run significantly faster
	/// TODO:
	/// Add Remove(T o) method - It's possible but I don't need it
	/// implement appropriate interfaces:
	/// IEnumerable?
	/// </summary>
	public class GenericConcurrentMegaHash<T>
	{
		// After doing a bulk add, call AwaitAll() to ensure all data was added!
		private ConcurrentBag<Task> bag = new ConcurrentBag<Task>();
		private int primitiveIteratorTreshold;
		private ConcurrentDictionary<string, List<T>> dictionary = new ConcurrentDictionary<string, List<T>>();
		private Dictionary<string, T> dictionaryForOveryLongEntries = new Dictionary<string, T>();
		// consider changing this to include for example '-'
		public char[] splitChars;
		public GenericConcurrentMegaHash() : this(21)
		{
			primitiveIteratorTreshold = 21;
		}
		/// <summary>
		/// Use this constructor to manaully set the string length treshold for items to be put in the dictionary for overly long entries.
		/// Slower computers might need a lower value
		/// a 4 core i5 @ 3.06 Ghz takes ~<1s for a String that is 21 characters long
		/// Consider increasing the processes priority during bulk adds
		/// </summary>
		public GenericConcurrentMegaHash(int primitiveIteratorTreshold)
		{
			this.primitiveIteratorTreshold = primitiveIteratorTreshold;
			splitChars = new char[] { ' ' };
		}
		public void Add(string keyWords, T o)
		{
			keyWords = keyWords.ToUpper();
			foreach (string keyWord in keyWords.Split(splitChars))
			{
				if (keyWord == null || keyWord.Length < 1)
					return;
				if(keyWord.Length > primitiveIteratorTreshold)
				{
					if(!dictionaryForOveryLongEntries.ContainsValue(o))
						dictionaryForOveryLongEntries.Add(keyWord, o);
					continue;
				}
				this.bag.Add( Task.Factory.StartNew(() => { AddInternal(keyWord, o); }));
			}
		}
		public void AwaitAll()
		{
			lock (this.bag)
			{
				foreach(Task t in bag)
					t.Wait();
				this.bag = new ConcurrentBag<Task>();
			}
		}
		private void AddInternal(string key, T y)
		{
			if (!dictionary.ContainsKey(key))
			{
				List<T> tempList = new List<T>();
				tempList.Add(y);
				dictionary[key] = tempList;
			}
			else
			{
				if (!dictionary[key].Contains(y))
					dictionary[key].Add(y);
			}
			if (key.Length == 1)
				return;
			AddInternal(key.Substring(1), y);
			AddInternal(key.Substring(0, key.Length - 1), y);
		}
		public IList<T> FulltextSearch(string searchString)
		{
			searchString = searchString.ToUpper();
			List<T> list = new List<T>();
			string[] searchWords = searchString.Split(splitChars);
			foreach(string arg in searchWords)
			{
				if (arg == null || arg.Length < 1)
					continue;
				if (dictionary.ContainsKey(arg))
					foreach (T obj in dictionary[arg])
						if(!list.Contains(obj))
							list.Add(obj);		
			}
			Parallel.ForEach(dictionaryForOveryLongEntries.Keys, (el) =>
			{
				foreach (string x in searchWords)
				{
					if (x == null || x.Length == 0)
						continue;
					if (!el.Contains(x))
						return;
				}
				list.Add(dictionaryForOveryLongEntries[el]);
			});
			return list;
		}
	}
}
