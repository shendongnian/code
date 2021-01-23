    private void LoadItems()
    {
    	using(StreamReader sr = new StreamReader("file.txt"))
    	{
    		while (!sr.EndOfStream)
    		{
    			listBox1.Items.Add(sr.ReadLine());
    		}
    	}
    }
