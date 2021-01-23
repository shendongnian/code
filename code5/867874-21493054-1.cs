    public class CNode<T>
    {
    	...
    	
    	public override string ToString()
    	{
    		return item.ToString();
    	}
        virtual public void Print()
        {
            Console.WriteLine(item);
        }	
    }
    
    class CList<T>
    {
    	...
    	
    	public void PrintList()
    	{
    		CNode<T> current = first;
    		while (current != null)
    		{
    			Console.WriteLine(current.ToString());
    			current = current.Next;
    		}
    	}
    }
