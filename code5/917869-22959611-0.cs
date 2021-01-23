    [Serializable]
    class Node
    {
    	byte[][] a;
    	int[] b;
    	List<Node> c;
    	public Node()
    	{
    		a = new byte[3][];
    		b = new int[3];
    		c = new List<Node>(0);
    	}
    }
    
    [Test]
    public void GetSize()
    {
    
    	Node item = new Node();
    	object o = new object();
    	long size = 0;
    	using (Stream s = new MemoryStream())
    	{
    		BinaryFormatter formatter = new BinaryFormatter();
    		formatter.Serialize(s, item);
    		size = s.Length; // <<<<<  918 bytes on my machine
    	}
    }
