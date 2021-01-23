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
	    public class ImmutableListToReactive<T> : ReactiveObject, ICollection<T>, INotifyCollectionChanged, IDisposable
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
	                _Current = newVersion;
	                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
	            });
	        }
	
	        public void Add( T item )
	        {
	            _Source.OnNext(_Current.Add(item));
	            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
	        }
	
	        public void Clear()
	        {
	            _Source.OnNext(_Current.Clear());
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
	            var next = _Current.Remove(item);
	            if ( next == _Current )
	            {
	                return false;
	            }
	            else
	            {
	                _Source.OnNext(next);
	                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
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
	
	
	        protected virtual void OnCollectionChanged( NotifyCollectionChangedEventArgs e )
	        {
	            if ( CollectionChanged != null )
	            {
	                CollectionChanged(this, e);
	            }
	        }
	    }
	}
	
