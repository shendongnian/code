    public class A<T> where T : struct, IComparable <T>, IEquatable<T>
    {
    	public class Node
    	{
    		public T symbol;
    		public Node next;
    		public int freq;
    	}
    
    	public Node Front;
    
    	public A(string[] args, Func<byte[], int, T> converter)
    	{
    		int size = Marshal.SizeOf(typeof(T));
    		Front = null;
    		using(var stream = new BinaryReader(System.IO.File.OpenRead(args[0]))) 
    		{                    
    			while (stream.BaseStream.Position < stream.BaseStream.Length) 
    			{
    				byte[] bytes = stream.ReadBytes(size);
    				T processingValue = converter(bytes, 0);
    				Node pt, temp;
    				pt = Front;
    				while (pt != null)
    				{
    					if (pt.symbol.Equals(processingValue))
    					{
    						pt.freq++;
    						break;
    					}
    					temp = pt;
    					pt = pt.next;
    				}
    			}
    		}
    	}
    }
