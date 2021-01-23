    public class BlockingCollection<T>
    {
    	private readonly Queue<T> m_Queue = new Queue<T>();
    
    	public void Add(T item)
    	{
    		lock (m_Queue)
    		{
    			m_Queue.Enqueue(item);
    			Monitor.Pulse(m_Queue);
    		}
    	}
    
    	public T Take()
    	{
    		lock (m_Queue)
    		{
    			while (m_Queue.Count == 0)
    			{
    				Monitor.Wait(m_Queue);
    			}
    			return m_Queue.Dequeue();
    		}
    	}
    
    	public bool TryTake(out T item)
    	{
    		item = default(T);
    		lock (m_Queue)
    		{
    			if (m_Queue.Count > 0)
    			{
    				item = m_Queue.Dequeue();
    			}
    		}
    		return item != null;
    	}
    
    }
