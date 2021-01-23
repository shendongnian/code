	public class BaseIncrementalObservableCollection<T> : ObservableCollection<T>
		#region ISupportIncrementalLoading
		public bool HasMoreItems
		{
			get { return HasMoreItemsOverride(); }
		}
		public Windows.Foundation.IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
		{
			if (_busy)
			{
				throw new InvalidOperationException("Only one operation in flight at a time");
			}
			_busy = true;
			return AsyncInfo.Run((c) => LoadMoreItemsAsync(c, count));
		}
		#endregion 
		#region INotifyCollectionChanged
		public event NotifyCollectionChangedEventHandler CollectionChanged;
		#endregion 
		#region Private methods
		async Task<LoadMoreItemsResult> LoadMoreItemsAsync(CancellationToken c, uint count)
		{
			try
			{
				var items = await LoadMoreItemsOverrideAsync(c, count);
				var baseIndex = _storage.Count;
				_storage.AddRange(items);
				// Now notify of the new items
				NotifyOfInsertedItems(baseIndex, items.Count);
				return new LoadMoreItemsResult { Count = (uint)items.Count };
			}
			finally
			{
				_busy = false;
			}
		}
		void NotifyOfInsertedItems(int baseIndex, int count)
		{
			if (CollectionChanged == null)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, _storage[i + baseIndex], i + baseIndex);
				CollectionChanged(this, args);
			}
		}
		#endregion
		#region Overridable methods
		protected abstract Task<IList<T>> LoadMoreItemsOverrideAsync(CancellationToken c, uint count);
		protected abstract bool HasMoreItemsOverride();
		#endregion 
		#region State
		List<T> _storage = new List<T>();
		bool _busy = false;
		#endregion
	}
