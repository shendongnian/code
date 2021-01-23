    protected override void DependencyDispose()
    		{
    			CacheDependency[] array = null;
    			bool flag = false;
    			try
    			{
    				Monitor.Enter(this, ref flag);
    				this._disposed = true;
    				if (this._dependencies != null)
    				{
    					array = (CacheDependency[])this._dependencies.ToArray(typeof(CacheDependency));
    					this._dependencies = null;
    				}
    			}
    			finally
    			{
    				if (flag)
    				{
    					Monitor.Exit(this);
    				}
    			}
    			if (array != null)
    			{
    				CacheDependency[] array2 = array;
    				for (int i = 0; i < array2.Length; i++)
    				{
    					CacheDependency cacheDependency = array2[i];
    					cacheDependency.DisposeInternal();
    				}
    			}
    		}
