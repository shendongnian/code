    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace ManagerTest
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var Manager = new TestManager();
    			Manager.ItemAdded += (manager, item) => Debug.WriteLine("Item added: " + item.Id);
    			Manager.ItemRemoved += (manager, item) => Debug.WriteLine("Item removed: " + item.Id);
    
    			var entity1 = Manager.Create("entity1");
    			var entity2 = Manager.Create("entity2");
    			Manager.Remove("entity1");
    			var entity3 = Manager.Create("entity3");
    			Manager.Remove("entity3");
    			Manager.Remove("entity4");
    		}
    	}
    
    	class TestClass : EntityBase, IDisposable
    	{
    		public TestClass(string id, TestManager manager) : base(id, manager) { Debug.WriteLine(Id + " - ctor"); }
    		public void Dispose() { Debug.WriteLine(Id + " - disposed"); }
    	}
    
    	class TestManager : ManagerBase<TestClass>, IManagerBase<TestClass>
    	{
    		protected override TestClass CreateInternal(string key) { return new TestClass(key, this); }
    		protected override void FinalizeRemove(TestClass item) { item.Dispose(); }
    	}
    
    	abstract class EntityBase
    	{
    		public string Id { get; private set; }
    		public IManagerBase<EntityBase> Manager { get; private set; }
    
    		public EntityBase(string id, IManagerBase<EntityBase> manager)
    		{
    			this.Id = id;
    			this.Manager = manager;
    		}
    	}
    
    	interface IManagerBase<out T>
    		where T : EntityBase
    	{
    		event Action<IManagerBase<T>, T> ItemAdded;
    		event Action<IManagerBase<T>, T> ItemRemoved;
    		T Create(string key);
    		T Get(string key);
    		bool Contains(string key);
    		bool Remove(string key);
    	}
    
    	abstract class ManagerBase<T> : IManagerBase<T> where T : EntityBase
    	{
    		public event Action<IManagerBase<T>, T> ItemAdded;
    		public event Action<IManagerBase<T>, T> ItemRemoved;
    
    		private readonly Dictionary<string, T> Storage = new Dictionary<string, T>();
    
    		protected abstract T CreateInternal(string key);
    		protected abstract void FinalizeRemove(T item);
    
    		public T Create(string key)
    		{
    			T newItem = null;
    
    			lock (Storage)
    			{
    				if (!Storage.ContainsKey(key))
    				{
    					Storage.Add(key, CreateInternal(key));
    
    					ItemAdded.SafeInvoke(this, newItem);
    				}
    			}
    
    			return newItem;
    		}
    
    		public T Get(string key)
    		{
    			lock (Storage)
    				return Storage.ContainsKey(key) ? Storage[key] : null;
    		}
    
    		public bool Contains(string key)
    		{
    			lock (Storage)
    				return Storage.ContainsKey(key);
    		}
    
    		public bool Remove(string key)
    		{
    			bool returnValue = false;
    
    			lock (Storage)
    				if (Storage.ContainsKey(key))
    				{
    					var item = Storage[key];
    					returnValue = Storage.Remove(key);
    					ItemRemoved.SafeInvoke(this, item);
    					FinalizeRemove(item);
    				}
    
    			return returnValue;
    		}
    	}
    
    	static class Extensions
    	{
    		public static void SafeInvoke<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2)
    		{
    			var actionCopy = action;
    			if (actionCopy != null)
    				actionCopy(arg1, arg2);
    		}
    	}
    }
