	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reactive.Subjects;
	using System.Text;
	using System.Threading.Tasks;
	using System.Collections.Immutable;
	using System.Collections.Specialized;
	using ReactiveUI;
	
	namespace ReactiveUI.Ext
	{
	    public class ImmutableListToReactive<T> : ReactiveObject, ICollection<T>, INotifyCollectionChanged, IDisposable, IList<T>
	    where T : class, Immutable
	    {
	        private  ISubject<ImmutableList<T>> _Source;
	
	        ImmutableList<T> _Current;
	        public ImmutableList<T> Current
	        {
	            get { return _Current; }
	            set { this.RaiseAndSetIfChanged(ref _Current, value); }
	        }
	
	        public void Dispose()
	        {
	            _Subscription.Dispose();
	        }
	
	
	        public ImmutableListToReactive( ISubject<ImmutableList<T>> source )
	        {
	            _Source = source;
	            _Subscription = source.Subscribe(newVersion =>
	            {
	                if ( !rebound )
	                {
	                    _Current = newVersion;
	                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	                }
	            });
	        }
	
	        private void OnNext( ImmutableList<T> list )
	        {
	            rebound = true;
	            _Current = list;
	            try
	            {
	                _Source.OnNext(list);
	            }
	            finally
	            {
	                rebound = false;
	            }
	        }
	
	        public void Add( T item )
	        {
	            OnNext(_Current.Add(item));
	            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new List<T>(){item}, Current.Count - 1));
	        }
	
	        public void Clear()
	        {
	            OnNext(_Current.Clear());
	            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	        }
	
	        public bool Contains( T item )
	        {
	            return _Current.Contains(item);
	        }
	
	        public void CopyTo( T[] array, int arrayIndex )
	        {
	            _Current.CopyTo(array, arrayIndex);
	        }
	
	        public int Count
	        {
	            get { return _Current.Count; }
	        }
	
	        public bool IsReadOnly
	        {
	            get { return false; }
	        }
	
	        public bool Remove( T item )
	        {
	            var idx = _Current.IndexOf(item);
	            var next = _Current.Remove(item);
	            if ( next == _Current )
	            {
	                return false;
	            }
	            else
	            {
	                OnNext(next);
	                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, idx));
	                return true;
	            }
	        }
	
	        public IEnumerator<T> GetEnumerator()
	        {
	            return _Current.GetEnumerator();
	        }
	
	        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
	        {
	            return _Current.GetEnumerator();
	        }
	
	        public event NotifyCollectionChangedEventHandler CollectionChanged;
	        private  IDisposable _Subscription;
	
	
	        bool rebound = false;
	        protected virtual void OnCollectionChanged( NotifyCollectionChangedEventArgs e )
	        {
	            if ( !rebound )
	            {
	                rebound = true;
	                if ( CollectionChanged != null )
	                {
	                    CollectionChanged(this, e);
	                }
	                rebound = false;
	            }
	        }
	
	        public int IndexOf( T item )
	        {
	            return _Current.IndexOf(item);
	        }
	
	        public void Insert( int index, T item )
	        {
	            OnNext(_Current.Insert(index, item));
	            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
	        }
	
	        public void RemoveAt( int index )
	        {
	            var itemToBeRemoved = _Current[index];
	            OnNext(_Current.RemoveAt(index));
	            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, itemToBeRemoved, index));
	        }
	
	        public T this[int index]
	        {
	            get
	            {
	                return _Current[index];
	            }
	            set
	            {
	                OnNext(_Current.SetItem(index, value));
	                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, value, index));
	                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, value, index));
	            }
	        }
	    }
	}
		
